using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedCommon.Entities;
using SharedCommon.Interfaces;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class CourseRepository : ICourseRepository
    {
        private readonly IDBConfig dBConfig;
        public CourseRepository(IDBConfig dBConfig)
        {
            this.dBConfig = dBConfig;
        }

        public List<Course> GetCourses()
        {
            var courses = new List<Course>();
            using (var connection = new SqlConnection(dBConfig.GetConnectionString()))
            {
                string sqlQuery = "SELECT ID, Name,  Credits, ProgramID, Description, HasPrerequisite, isRequired FROM COURSE";
                using (var command = new SqlCommand(sqlQuery))
                {
                    command.Connection = connection;
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            //Console.WriteLine("{0}, {1}", reader.GetString(0), reader.GetString(1));
                            var course = new Course() { ID = reader.GetString(0), Name = reader.GetString(1), Credits = reader.GetInt32(2), ProgramID = reader.GetString(3), Description = reader.GetString(4), HasPrerequisite = reader.GetBoolean(5), isRequired = reader.GetBoolean(6)};
                            courses.Add(course);
                        }
                    }
                }
            }
            return courses;
        }

        public List<StudentCourse> GetStudentCompletedCourses(string studentID)
        {
            var studentcourses = new List<StudentCourse>();
            using (var connection = new SqlConnection(dBConfig.GetConnectionString()))
            {
                string query = (@$"SELECT sc.CourseID, sc.Grade, c.Description 
                                FROM StudentCourse sc
                                INNER JOIN Course c ON c.ID = sc.CourseID
                                WHERE(StudentID = '{studentID}' AND isCompleted = 'True')");
                using (var command = new SqlCommand(query))
                {
                    command.Connection = connection;
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var studentcourse = new StudentCourse() {CourseID=reader.GetString(0), Grade=reader.GetSqlValue(1).ToString(), Description=reader.GetString(2)};
                            studentcourses.Add(studentcourse);
                        }
                    }
                }
            }
            return studentcourses;
        }

        public List<Course> GetCurrentdCourses(string studentID)
        {
            var studentcourses = new List<Course>();
            using (var connection = new SqlConnection(dBConfig.GetConnectionString()))
            {
                string query = (@$"SELECT sc.CourseID, c.Description 
                                FROM StudentCourse sc
                                INNER JOIN Course c ON c.ID = sc.CourseID
                                WHERE(StudentID = '{studentID}' AND isCompleted = 'False')");
                using (var command = new SqlCommand(query))
                {
                    command.Connection = connection;
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var studentcourse = new Course() { ID = reader.GetString(0), Description = reader.GetString(2) };
                            studentcourses.Add(studentcourse);
                        }
                    }
                }
            }
            return studentcourses;
        }
       
        public List<Course> GetStudentRecommendedCourses(string studentID)
        {
            var noPrereqCourses = new List<Course>();
            var completedCourses = new List<Course>();
            var coursesWithPrereq = new List<CoursePrerequisite>();
            
            using (var connection = new SqlConnection(dBConfig.GetConnectionString()))
            {
                string query1 = (@$"SELECT sc.CourseID, c.Description
                                    FROM StudentCourse sc
                                    INNER JOIN Course c ON c.ID = sc.CourseID
                                    WHERE(sc.StudentID = '10564' AND sc.isCompleted IS NULL AND c.HasPrerequisite = 0)");
                using (var command = new SqlCommand(query1))
                {
                    command.Connection = connection;
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var course = new Course() { ID = reader.GetString(0), Description = reader.GetString(1)};
                            noPrereqCourses.Add(course);
                        }
                    }
                    connection.Close();
                }
                string query2 = (@"SELECT sc.CourseID
                                    FROM StudentCourse sc
                                    INNER JOIN Course c ON c.ID = sc.CourseID
                                    WHERE(sc.StudentID = '10564' AND sc.isCompleted = 'True')");
                using (var command = new SqlCommand(query2))
                {
                    command.Connection = connection;
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var course = new Course() { ID = reader.GetString(0) };
                            completedCourses.Add(course);
                        }
                    }
                    connection.Close();
                }
                string query3 = (@$"SELECT sc.CourseID, c1.Description, cs.PrerequisiteID, cs.PrerequisiteComposite
                                FROM StudentCourse sc
                                INNER JOIN Course c1 ON c1.ID = sc.CourseID
                                INNER JOIN CoursePrerequisite cs ON cs.CourseID = sc.CourseID
                                WHERE(sc.StudentID = '10564' AND (sc.isCompleted = 'False' OR sc.isCompleted IS NULL) AND c1.HasPrerequisite = 1)");
                using (var command = new SqlCommand(query3)) 
                {
                    command.Connection = connection;
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var course = new CoursePrerequisite() { CourseID =reader.GetString(0), Description=reader.GetString(1), PrerequisiteID=reader.GetString(2), PrerequisiteComposite=reader.GetSqlValue(3).ToString() };
                            coursesWithPrereq.Add(course);
                        }
                    }
                    connection.Close();
                }
            }

            var andCoursesHolder = new List<Course>();

            foreach (CoursePrerequisite cp in coursesWithPrereq)
            {
                
                if (cp.PrerequisiteComposite == "or")
                {                    
                    if (completedCourses.Exists(x => x.ID == cp.PrerequisiteID))
                    {
                        if (noPrereqCourses.Exists(x => x.ID == cp.CourseID))
                        {
                            continue;
                        }
                        Course cs = new Course() { ID = cp.CourseID, Description = cp.Description };
                        noPrereqCourses.Add(cs);
                    }
                }
                else if (cp.PrerequisiteComposite == "and")
                {
                    if (completedCourses.Exists(x => x.ID == cp.PrerequisiteID))
                    {
                        Course cs = new Course() { ID = cp.CourseID, Description = cp.Description };
                        if (andCoursesHolder.Any() || andCoursesHolder.Exists(x => x.ID == cp.CourseID))
                        {                                    
                            noPrereqCourses.Add(cs);
                        }
                        else
                        {
                            andCoursesHolder.Add(cs);
                        }                       
                        continue;
                    }
                }
                else
                {
                    if (completedCourses.Exists(x => x.ID == cp.PrerequisiteID))
                    {
                        Course cs = new Course() { ID = cp.CourseID, Description = cp.Description };
                        noPrereqCourses.Add(cs);
                        continue;
                    }
                }
            }
            noPrereqCourses.Sort((x, y) => x.ID.CompareTo(y.ID));
            return noPrereqCourses;
        }

        public List<Course> GetCourses(string CourseIDFilter)
        {
            throw new NotImplementedException();
        }
    }
}
