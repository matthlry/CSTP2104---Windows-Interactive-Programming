using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedCommon.Entities
{
    public class Course
    {
        public string CourseID { get; set; }
        public string CourseName { get; set; }
        public string CourseDescription { get; set; }
        public bool HasPrerequisite { get; set; }

    }
}
