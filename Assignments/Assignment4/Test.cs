using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Assignment4
{
    public class Test
    {
        public static void ReadDB()
        {
            var db = new DBAssignment();
            db.CreateInsertQuery();
        }
    }
}
