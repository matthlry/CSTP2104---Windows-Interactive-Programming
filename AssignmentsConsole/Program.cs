using System;
using Assignment.Assignment1;
using Assignment.Assignment4;
using DataAccessLayer;
using SharedCommon.Entities;

namespace AssignmentsConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Student newStudent = new Student { ID = 10321, Name = "John Dee", ProgramID = "CSTP" };
            DataAccessLayer.Test.AddStudentToProgram(newStudent);

            DataAccessLayer.Test.GetRecommendation("10321"); // TEST 10963, 10564, 10321
            //DataAccessLayer.Test.GetRecommendationelectives("10564");
            //DataAccessLayer.Test.GetStudentsAllowed("ACC201", "AP");
            //DataAccessLayer.Test.GetFilteredRecommendation("10564", 2023, 2);
        }
    }
}
