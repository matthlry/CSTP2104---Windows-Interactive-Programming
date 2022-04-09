using SharedCommon.Entities;
using SharedCommon.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class StudentManager
    {
        private readonly IStudentRepository studentRepository;
        private readonly ICourseRepository courseRepository;
        public StudentManager(IStudentRepository studentRepository, ICourseRepository courseRepository)
        {
            this.studentRepository = studentRepository;
            this.courseRepository = courseRepository;
        }
        public List<Student> GetRegisteredStudents(Filter filter)
        {
            List<Student> students;
            students = this.studentRepository.GetStudents(filter);

            if (students != null)
            {
                return students;
            }
            students = new List<Student>();
            return students;
        }
        public List<Student> GetAllowedStudentsInACourse(string courseID, string programID)
        {
            List<Student> students;
            students = this.studentRepository.GetStudentsAllowedForCourse(courseID, programID);

            if (students != null)
            {
                return students;
            }
            students = new List<Student>();
            return students;
        }
        public List<Course> GetStudentRecommendedCourses(Filter filter)
        {
            List<Course> courses;
            courses = this.courseRepository.GetStudentRecommendedCourses(filter.ID);

            if (courses != null)
            {
                return courses;
            }
            courses = new List<Course>();
            return courses;
        }
        public List<Course> GetStudentRecommendedElectives(Filter filter)
        {
            List<Course> courses;
            courses = this.courseRepository.GetStudentRecommendedElectives(filter.ID);

            if (courses != null)
            {
                return courses;
            }
            courses = new List<Course>();
            return courses;
        }
        public List<Course> GetStudentCurrentCourses(Filter filter)
        {
            List<Course> courses;
            courses = this.courseRepository.GetCurrentCourses(filter.ID);

            if (courses != null)
            {
                return courses;
            }
            courses = new List<Course>();
            return courses;
        }
        public List<StudentCourse> GetStudentCompletedCourses(Filter filter)
        {
            List<StudentCourse> studentCourses;
            studentCourses = this.courseRepository.GetStudentCompletedCourses(filter.ID);

            if (studentCourses != null)
            {
                return studentCourses;
            }
            studentCourses = new List<StudentCourse>();
            return studentCourses;
        }

        public void AddStudentToProgram(Student student)
        {
            bool success = this.studentRepository.Add(student);
            if (success)
            {
                Console.WriteLine("Successfuly Added the Student");
                return;
            }
            Console.WriteLine("Cannot Add Student");
        }
    }
}
