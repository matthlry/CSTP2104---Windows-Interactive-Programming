using SharedCommon.Entities;
using SharedCommon.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class StudentRegistrationManager
    {
        private readonly IStudentRepository studentRepository;
        public StudentRegistrationManager(IStudentRepository studentRepository)
        {
            this.studentRepository = studentRepository;
        }

        public List<Student> GetRegisteredStudents(Filter filter)
        {
            var students = this.studentRepository.GetStudents(filter);

            return students;
        }
    }
}
