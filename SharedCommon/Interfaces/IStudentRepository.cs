using SharedCommon.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedCommon.Interfaces
{
    public interface IStudentRepository
    {
        List<Student> GetStudents(Filter filter);
        Student Get(string studentID);
        public bool Add(Student student);
        public void Update(Student student);
        public void Delete(string studentID);
        List<Student> GetStudentsAllowedForCourse(string courseID, string progamID);

    }
}
