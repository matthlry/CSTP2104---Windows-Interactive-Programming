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
            _Engine = engine;
            _Model = model;
            _Make = make;
            _Trim = trim;
        }
        private MotorcycleEngine _Engine;
        private MotorcycleModel _Model;
        private MotorcycleTrim _Trim;
        private MotorcycleMake _Make;
        public MotorcycleEngine Engine
        {
            get { return _Engine; }
            set { _Engine = value; }
        }
        public MotorcycleModel Model
        {
            get { return _Model; }
            set { _Model = value; }
        }
        public MotorcycleTrim Trim
        {
            get { return _Trim; }
            set { _Trim = value; }
        }
        public MotorcycleMake Make
        {
            get { return _Make; }
            set { _Make = value; }
        }
    }
}

