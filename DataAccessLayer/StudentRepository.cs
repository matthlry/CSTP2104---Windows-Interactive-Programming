using SharedCommon.Entities;
using SharedCommon.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class StudentRepository : IStudentRepository
    {
        private readonly IDBConfig dBConfig;
        public StudentRepository(IDBConfig dBConfig)
        {
            this.dBConfig = dBConfig;
        }
        public List<Student> GetStudents(Filter filter)
        {
            var students = new List<Student>();
            try
            {
                using (var connection = new SqlConnection(dBConfig.GetConnectionString()))
                {
                    string sqlQuery = ($"SELECT * FROM STUDENT WHERE ID = '{filter.ID}' OR Name = '{filter.Name}'");
                    using (var command = new SqlCommand(sqlQuery))
                    {
                        command.Connection = connection;
                        connection.Open();
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var student = new Student() { ID = reader.GetInt32(0), Name = reader.GetString(1), ProgramID = reader.GetString(2) };
                                students.Add(student);
                            }
                        }
                    }
                }
                return students;
            }
            catch (Exception ex)
            {
                return null;
            }            
        }
        public Student Get(string studentID)
        {
            using (var connection = new SqlConnection(dBConfig.GetConnectionString()))
            {
                string sqlQuery = ($"SELECT * FROM STUDENT WHERE ID = '{studentID}'");
                using (var command = new SqlCommand(sqlQuery))
                {
                    command.Connection = connection;
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        reader.Read();
                        {
                            var student = new Student() { ID = reader.GetInt32(0), Name = reader.GetString(1), ProgramID = reader.GetString(2) };
                            return student;
                        }
                    }
                }
            }           
        }

        public List<Student> GetStudentsAllowedForCourse(string courseID, string programID)
        {
            var studentsList = new List<Student>();
            var studentsNotCompleted = new List<Student>();
            var studentsCompletedPrereq = new List<Student>();

            Course course = new Course();
            List<CoursePrerequisite> prePreqs = new List<CoursePrerequisite>();

            using (var connection = new SqlConnection(dBConfig.GetConnectionString()))
            {   
                try
                {
                    string queryCourse = ($@"SELECT c.ID, c.Name, pc.ProgramID, c.HasPrerequisite, c.Description, pc.isRequired, c.Credits  FROM Course c 
	                                        INNER JOIN ProgramCourse pc ON pc.CourseID = c.ID
                                            WHERE ID = '{courseID}' AND pc.ProgramID = '{programID}'");
                    {
                        using (var command = new SqlCommand(queryCourse))
                        {
                            command.Connection = connection;
                            connection.Open();
                            using (var reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    course = new Course { ID = reader.GetString(0), Name = reader.GetString(1), ProgramID = reader.GetString(2), HasPrerequisite = reader.GetBoolean(3), Description = reader.GetString(4), isRequired = reader.GetBoolean(5), Credits = reader.GetInt32(6) };
                                }
                            }
                            connection.Close();
                        }
                    }
                }
                catch (Exception ex)
                {
                    return null;
                }
                
                if (!course.HasPrerequisite)
                {
                    Console.WriteLine("HERE");
                    string query1 = ($@"SELECT sc.StudentID, s.Name, s.ProgramID
                                    FROM StudentCourse sc
                                    INNER JOIN Student s ON s.ID = sc.StudentID
                                    WHERE (sc.CourseID = '{course.ID}' AND sc.isCompleted IS NULL AND s.ProgramID = '{course.ProgramID}')");
                    using (var command = new SqlCommand(query1))
                    {
                        command.Connection = connection;
                        connection.Open();
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var student = new Student() { ID = reader.GetInt32(0), Name = reader.GetString(1), ProgramID = reader.GetString(2) };
                                studentsNotCompleted.Add(student);
                            }
                        }
                        connection.Close();
                        return studentsNotCompleted;
                    }
                }
                string query2 = ($@"SELECT * FROM CoursePrerequisite WHERE CourseID = '{course.ID}'");
                using (var command = new SqlCommand(query2))
                {
                    command.Connection = connection;
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var cp = new CoursePrerequisite() { CourseID = reader.GetString(0), PrerequisiteID = reader.GetString(1), PrerequisiteComposite = reader.GetValue(2).ToString() };
                            prePreqs.Add(cp);
                        }
                    }
                    connection.Close();
                }

                foreach (CoursePrerequisite cp in prePreqs)
                {
                    string query3 = ($@"SELECT s.ID, s.Name, s.ProgramID
                                    FROM Student s 
                                    INNER JOIN StudentCourse sc ON sc.StudentID = s.ID
                                    WHERE sc.CourseID = '{cp.PrerequisiteID}' AND sc.isCompleted = 'True'");
                    using (var command = new SqlCommand(query3))
                    {
                        command.Connection = connection;
                        connection.Open();
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var student = new Student() { ID = reader.GetInt32(0), Name = reader.GetString(1), ProgramID = reader.GetString(2) };                         
                                if (cp.PrerequisiteComposite == "or")
                                {
                                    if (studentsList.Exists(x => x.ID == student.ID))
                                    {
                                        continue;
                                    }
                                    studentsList.Add(student);
                                }
                                else if (cp.PrerequisiteComposite == "and")
                                {
                                    if (studentsCompletedPrereq.Exists(x => x.ID == student.ID))
                                    {
                                        studentsList.Add(student);
                                        continue;
                                    }
                                    studentsCompletedPrereq.Add(student);
                                }
                                else
                                {
                                    studentsList.Add(student);
                                }
                            }
                        }
                        connection.Close();
                    }                   
                }                  
            }
            return studentsList;
        }
        public void Add(Student student)
        {
            using (var connection = new SqlConnection(dBConfig.GetConnectionString()))
            {
                string sqlQuery = ($"INSERT INTO STUDENT VALUES ({student.ID}, {student.Name}, {student.ProgramID}");
                using (var command = new SqlCommand(sqlQuery))
                {
                    command.Connection = connection;
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
        public void Update(Student student)
        {
            using (var connection = new SqlConnection(dBConfig.GetConnectionString()))
            {
                string sqlQuery = ($"UPDATE STUDENT SET Name = '{student.Name}', ProgramID = '{student.ProgramID}' WHERE ID = '{student.ID}'");
                using (var command = new SqlCommand(sqlQuery))
                {
                    command.Connection = connection;
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
        public void Delete(string studentID)
        {
            using (var connection = new SqlConnection(dBConfig.GetConnectionString()))
            {
                string sqlQuery = ($"DELETE FROM STUDENT WHERE ID = '{studentID}'");
                using (var command = new SqlCommand(sqlQuery))
                {
                    command.Connection = connection;
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
