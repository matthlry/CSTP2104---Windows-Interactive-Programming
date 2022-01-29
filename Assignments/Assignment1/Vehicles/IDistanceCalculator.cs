using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Assignment1
{
    public interface IDistanceCalculator
    {
        double EstimateRemainingDistance();
        double EstimateNeededFuelForDistance(double d);
    }
}
