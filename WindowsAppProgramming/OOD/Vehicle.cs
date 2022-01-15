using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsAppLib.OOD
{
    public class Vehicle
    {
        public string Model;
        public int Year;
        public Makes Make;
        public Engines Engine;

        public virtual int GetMaxSpeed()
        {
            return 0;
        }
    }
}
