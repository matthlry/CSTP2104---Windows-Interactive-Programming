using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsAppLib.OOD
{
    public class Car : Vehicle
    {
        public string Trim;
        public string BodyType;
        

        public decimal Kilometers;
        public decimal Price;

        public Car()
        {
            Engine = Engines.Cylinders_4;
        }
        public Car(string model)
        {
            this.Model = model;
        }

    }
}
