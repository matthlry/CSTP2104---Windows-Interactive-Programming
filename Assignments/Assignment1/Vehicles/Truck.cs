using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment.Assignment1.Vehicle_Enum;
using Assignment.Assignment1.Vehicle_Enum.Truck_Enum;

namespace Assignment.Assignment1.Vehicles
{
    public class Truck : Vehicle
    {
        public Truck(TruckEngine engine, TruckModel model, TruckTrim trim, TruckMake make, int year, decimal price, int mileage, bool USvehicle, VehicleType type = VehicleType.Car) : base(type, year, price, mileage, USvehicle)
        {
            _Engine = engine;
            _Model = model;
            _Make = make;
            _Trim = trim;
        }
        private TruckEngine _Engine;
        private TruckModel _Model;
        private TruckTrim _Trim;
        private TruckMake _Make;
        public TruckEngine Engine
        {
            get { return _Engine; }
            set { _Engine = value; }
        }
        public TruckModel Model
        {
            get { return _Model; }
            set { _Model = value; }
        }
        public TruckTrim Trim
        {
            get { return _Trim; }
            set { _Trim = value; }
        }
        public TruckMake Make
        {
            get { return _Make; }
            set { _Make = value; }
        }
    }
}

