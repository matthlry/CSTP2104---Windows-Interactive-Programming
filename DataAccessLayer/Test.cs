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

        public static void GetStudent()
        {
            Student theStudent = st.Get("123456");
            Console.WriteLine($"{theStudent.Name} {theStudent.ID.ToString()} {theStudent.ProgramID}");
        }
    }
}
