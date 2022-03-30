using System;
using Assignment.Assignment1;
using Assignment.Assignment4;
using DataAccessLayer;

namespace AssignmentsConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            DataAccessLayer.Test.GetRecommendation("10564"); // TEST 10963 and 10564
            //DataAccessLayer.Test.GetRecommendationelectives("10564");
            //DataAccessLayer.Test.GetStudentsAllowed("ACC201", "AP");
            DataAccessLayer.Test.GetFilteredRecommendation("10564", 2023, 2);
        }
    }
}
