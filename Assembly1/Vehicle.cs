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
        Type type;
        
        public Vehicle(string regNum, Type type)
        {
            this.regNum = regNum;
            this.type = type;
            this.arrival = DateTime.Now;
        }
        public Type Type 
        {
            get => this.type;
        }
        public string RegNum 
        { 
            get => this.regNum; 
        }
        public DateTime Arrival 
        { 
            get => this.arrival; 
        }

        public decimal Getcost {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("\n" + this.regNum);
            sb.Append("\n" + this.type.ToString());
            sb.Append("\n" + this.arrival.ToString());
            return sb.ToString();
        }
    }




}
