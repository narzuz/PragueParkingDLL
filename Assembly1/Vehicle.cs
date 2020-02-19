using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly1
{
    public class Vehicle : IVehicle
    {
        public Enum Type { get; }
        public string RegNum { get; }
        public DateTime Arrival { get; }

        public decimal Getcost {
            get
            {
                throw new NotImplementedException();
            }
            //heello
        }

        public override string ToString()
        {
            return $"{this.Type}\n{this.RegNum}\n{this.Arrival}";
        }
    }




}
