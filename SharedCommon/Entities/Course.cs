using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedCommon.Entities
{
    public class Course
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ProgramID { get; set; }
        public bool HasPrerequisite { get; set; }
        public bool isRequired { get; set; }
        public int Credits { get; set; }
        public int Year { get; set; }
        public int Term { get; set; }
    }
}
