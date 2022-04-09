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

            if (sc.Any()) {
                foreach (StudentCourse course in sc)
                {
                    Console.WriteLine($"{course.CourseID}, {course.Description}, {course.Grade}");
                }
                return;
            }
            Console.WriteLine("Student Not Found");
        }

        public static void GetRecommendation(string id)
        {
            List<Course> c = cr.GetStudentRecommendedCourses(id);

            if (c.Any())
            {
                foreach (Course course in c)
                {
                    Console.WriteLine($"{course.ID} {course.Description} {course.Year} {course.Term}");
                }
                return;
            }
            Console.WriteLine("Student Not Found");
        }

       public static void GetRecommendationelectives(string id)
        {
            List<Course> c = cr.GetStudentRecommendedElectives(id);

            if(c.Any())
            {
                foreach (Course course in c)
                {
                    Console.WriteLine($"{course.ID} {course.Description} {course.Year} {course.Term}");
                }
                return;
            }
            Console.WriteLine("Student Not Found");
        }
        public static void GetFilteredRecommendation(string id, int year, int term)
        {
            List<Course> c = cr.GetFilteredRecommendedCoursesByYearTerm(id, year, term);

            if (c.Any())
            {
                foreach (Course course in c)
                {
                    Console.WriteLine($"{course.ID} {course.Description} {course.Year} {course.Term}");
                }
                return;
            }
            Console.WriteLine("Student Not Found");
        }

        public static void GetStudentsAllowed(string courseID, string programID)
        {
            List<Student> s = st.GetStudentsAllowedForCourse(courseID, programID);
            if (s.Any())
            {
                foreach (Student student in s)
                {
                    Console.WriteLine($"{student.Name} {student.ID}");
                }
                return;
            }            
            Console.WriteLine("Course Not Found");
        }
    }
}
