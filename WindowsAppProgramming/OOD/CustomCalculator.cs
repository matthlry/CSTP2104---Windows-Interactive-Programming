using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsAppLib.OOD
{
    public class CustomCalculator : ICalculator
    {
        public int Calculate(int x)
        {
            return ((x * x) + 8) / 2;
        }
    }
}
