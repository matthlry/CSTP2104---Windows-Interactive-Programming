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
                string sqlQuery = "SELECT CourseID, CourseName, CourseDescription, HasPrerequisite FROM COURSE";
                using (var command = new SqlCommand(sqlQuery))
                {
                    command.Connection = connection;
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            //Console.WriteLine("{0}, {1}", reader.GetString(0), reader.GetString(1));
                            var course = new Course() { CourseID = reader.GetString(0), CourseName = reader.GetString(1), CourseDescription = reader.GetString(2), HasPrerequisite = reader.GetBoolean(3)};
                            courses.Add(course);
                        }
                    }
                }
            }
            return courses;
        }

        public List<Course> GetCourses(string CourseIDFilter)
        {
            throw new NotImplementedException();
        }
    }
}
