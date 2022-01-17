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
        public Truck(TruckEngine engine, TruckModel model, TruckTrim trim, TruckMake make, int year, decimal price, int mileage, bool USvehicle, bool damaged = false) : base(year, price, mileage, USvehicle)
        {
            if (damaged)
            {
                _IsDamaged = damaged;
            }
            _Type = VehicleType.Truck;
            _Engine = engine;
            _Model = model;
            _Make = make;
            _Trim = trim;
            _CurrentFuel = 0D;
            if (_Engine == TruckEngine.Unknown)
            {
                _FuelTankMax = 0D;
                _FuelMileage = 0;
            }
            else if (_Engine == TruckEngine.Cylinders_8)
            {
                _FuelTankMax = 117D;
                _FuelMileage = 5.1;
            }
            else if (_Engine == TruckEngine.Cylinders_10)
            {
                _FuelTankMax = 143D;
                _FuelMileage = 4.5;
            }
            else if (_Engine == TruckEngine.Cylinders_12)
            {
                _FuelTankMax = 162D;
                _FuelMileage = 3.8;
            }
        }
        private TruckEngine _Engine;
        private TruckModel _Model;
        private TruckTrim _Trim;
        private TruckMake _Make;
        private double _FuelTankMax;
        private double _CurrentFuel;
        private double _FuelMileage;
        public TruckEngine Engine
        {
            get { return _Engine; }
            set { 
                _Engine = value;
                if (_Engine == TruckEngine.Unknown)
                {
                    _FuelTankMax = 0D;
                    _FuelMileage = 0;
                }
                else if (_Engine == TruckEngine.Cylinders_8)
                {
                    _FuelTankMax = 117.00D;
                    _FuelMileage = 5.1;
                }
                else if (_Engine == TruckEngine.Cylinders_10)
                {
                    _FuelTankMax = 143D;
                    _FuelMileage = 4.5;
                }
                else if (_Engine == TruckEngine.Cylinders_12)
                {
                    _FuelTankMax = 162D;
                    _FuelMileage = 3.8;
                }
            }
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
        public void FuelUp(double fuel)
        {
            if (fuel <= 0 || _Engine == TruckEngine.Unknown)
            {
                return;
            }
            if (_CurrentFuel + fuel >= _FuelTankMax)
            {
                _CurrentFuel = _FuelTankMax;
                return;
            }
            _CurrentFuel += fuel;
        }
        public double EstimateDistance()
        {
            if (_Engine == TruckEngine.Unknown)
            {
                return 0;
            }
            else
            {
                return Math.Round(_FuelMileage * _CurrentFuel, 2);
            }
        }
    }
}

