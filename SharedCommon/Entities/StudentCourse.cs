using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedCommon.Entities
{
    public class StudentCourse
    {
        public int StudentID { get; set; }
        public string CourseID { get; set; }
        public bool isCompleted { get; set; }
        public string Grade { get; set; }
        public string SemesterID { get; set; }
        public string Description { get; set; }


}
}
