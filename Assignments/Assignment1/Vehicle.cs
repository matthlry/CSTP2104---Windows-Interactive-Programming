using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment.Assignment1.Vehicle_Enum;

namespace Assignment.Assignment1
{
    public class Vehicle
    {
        public Vehicle(VehicleType type, int year, decimal price, int mileage, bool USvehicle)
        {
            _Type = type;
            _Year = year;
            _Price = price;
            _Mileage = mileage;
            if (USvehicle == true)
            {
                _MileageType = MileageType.miles;
            }
            else
            {
                _MileageType = MileageType.kms;
            }
        }

        protected int _Mileage;
        protected MileageType _MileageType;
        protected VehicleType _Type;
        protected int _Year;
        protected decimal _Price;

        public VehicleType Type
        {
            get { return _Type; }
            set { _Type = value; }
        }

        public int Year
        {
            get { return _Year; }
            set { _Year = value; }
        }

        public decimal Price
        {
            get { return _Price; }
            set { _Price = value; }
        }

        public string Mileage
        {
            get { return _Mileage.ToString() + _MileageType.ToString(); }
        }
            
    }
}
