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
            DataAccessLayer.Test.GetRecommendation("10564");
        }
    }
}
