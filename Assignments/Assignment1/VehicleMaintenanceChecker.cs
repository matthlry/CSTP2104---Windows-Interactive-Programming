using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Assignment1
{
    public static class VehicleMaintenanceChecker
    {
        public static bool isRepairNeeded(this Vehicle v)
        {
            if (v.isDamaged)
            {
                return true;
            }
            return false;
        }
    }
}
