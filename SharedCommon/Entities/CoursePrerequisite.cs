using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedCommon.Entities
{
    public class CoursePrerequisite
    {
        public string CourseID { get; set; }
        public string Description { get; set; }
        public string PrerequisiteID { get; set; }
        public string PrerequisiteComposite { get; set; }
}
}
