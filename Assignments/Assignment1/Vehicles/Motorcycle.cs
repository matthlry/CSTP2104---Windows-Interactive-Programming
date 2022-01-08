using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment.Assignment1.Vehicle_Enum;
using Assignment.Assignment1.Vehicle_Enum.Motorcycle_Enum;

namespace Assignment.Assignment1.Vehicles
{
    public class Motorcycle : Vehicle
    {
        public Motorcycle(MotorcycleEngine engine, MotorcycleModel model, MotorcycleTrim trim, MotorcycleMake make, int year, decimal price, int mileage, bool USvehicle, VehicleType type = VehicleType.Motorcycle) : base(type, year, price, mileage, USvehicle)
        {
            Engine = engine;
            Model = model;
            Make = make;
            Trim = trim;
        }
        public MotorcycleEngine Engine
        {
            get { return Engine; }
            set { Engine = value; }
        }
        public MotorcycleModel Model
        {
            get { return Model; }
            set { Model = value; }
        }
        public MotorcycleTrim Trim
        {
            get { return Trim; }
            set { Trim = value; }
        }
        public MotorcycleMake Make
        {
            get { return Make; }
            set { Make = value; }
        }
    }
}
}
