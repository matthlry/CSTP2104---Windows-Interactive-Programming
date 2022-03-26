using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedCommon.Entities;
namespace DataAccessLayer
{
    public class Test
    {
        static DBConfig dbconfig = new DBConfig();
        static StudentRepository st = new StudentRepository(dbconfig);
        static CourseRepository cr = new CourseRepository(dbconfig);

        public static void GetStudent()
        {
            Student theStudent = st.Get("123456");
            Console.WriteLine($"{theStudent.Name} {theStudent.ID.ToString()} {theStudent.ProgramID}");
        }

        public static void GetCompletedStudent(string id)
        {
            List<StudentCourse> sc = cr.GetStudentCompletedCourses(id);

            foreach(StudentCourse course in sc)
            {
                Console.WriteLine($"{course.CourseID}, {course.Description}, {course.Grade}");
            }
        }

        public static void GetRecommendation(string id)
        {
            List<Course> c = cr.GetStudentRecommendedCourses(id);

            foreach(Course course in c)
            {
                Console.WriteLine($"{course.ID} {course.Description}");
            }
        }

       public static void GetRecommendationelectives(string id)
        {
            List<Course> c = cr.GetStudentRecommendedElectives(id);

            foreach (Course course in c)
            {
                Console.WriteLine($"{course.ID} {course.Description}");
            }
        }

        public static void GetStudentsAllowed(string courseID, string programID)
        {
            List<Student> s = st.GetStudentsAllowedForCourse(courseID, programID);
            foreach (Student student in s)
            {
                Console.WriteLine($"{student.Name} {student.ID}");
            }
        }
    }
}
