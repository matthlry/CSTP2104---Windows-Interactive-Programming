using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsAppLib.OOD
{
    public class Suzuki : Motorcycle
    {
        public override int GetMaxSpeed()
        {
            if (this.Engine == Engines.Cylinders_4)
            {
                return 240;
            }
            return 180;
        }
    }
}
