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
