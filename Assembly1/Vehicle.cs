using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly1
{
    public class Vehicle : IVehicle
    {
        private string regNum;
        private DateTime arrival;

        
        public Vehicle(string regNum, Enum type)
        {
            this.regNum = regNum;
            this.Type = type;
        }
        private enum type
        {
            MC = 2,
            Car = 4,
        }
        public Enum Type { get; }
        public string RegNum { get; }
        public DateTime Arrival { get; }

        public decimal Getcost {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override string ToString()
        {
            return $"{this.Type}\n{this.regNum}\n{this.arrival}";
        }
    }




}
