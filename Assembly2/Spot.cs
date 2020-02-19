using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assembly1;

namespace Assembly2
{
    internal class Spot
    {
        internal List<IVehicle> vehicles = new List<IVehicle>();
        private int capacity;


        /// <summary>
        /// Returns sum of occupied space of current vehicles in the spot instance.
        /// </summary>
        /// <returns></returns>
        private int OccupiedCapacity()
        {
            int count = 0;
            foreach (var vehicle in vehicles)
            {
                count += (int)vehicle.Type;
            }
            return count;
        }

        internal Spot()
        {
        }
        internal Spot(int capacity)
        {
            this.capacity = capacity;
        }


        /// <summary>
        /// Read-Only, shows current available capacity.
        /// </summary>
        internal int GetAvailableCapacity
        {
           get => (this.capacity - OccupiedCapacity()); 
        }
        
        /// <summary>
        /// Adds one vehicle to the internal list of spot
        /// </summary>
        /// <param name="vehicle"></param>
        /// <returns></returns>
        internal bool AddVehicle(IVehicle vehicle)
        {
            int vehicleSize = (int)vehicle.Type;
            if (vehicleSize < GetAvailableCapacity)
            {
                vehicles.Add(vehicle);
                return true;
            }
            return false;
        }
        
        /// <summary>
        /// R
        /// </summary>
        /// <param name="regNum"></param>
        /// <returns></returns>
        internal IVehicle RemoveVehicle(string regNum)
        {
            foreach (var vehicle in this.vehicles)
            {
                if(vehicle.RegNum == regNum)
                {
                    vehicles.Remove(vehicle);
                    return vehicle;
                }
            }
            return null;
        }

        internal IVehicle FindVehicle(string regNum)
        {
            foreach (var vehicle in this.vehicles)
            {
                if(vehicle.RegNum == regNum)
                {
                    return vehicle;
                }
            }
            return null;
        }

        internal override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            if (this.vehicles.Count > 0)
            {
                foreach (var vehicles in this.vehicles)
                {
                    sb.Append(vehicles.ToString());
                }
                string output = sb.ToString();
                return output;
            }
            return base.ToString();
        }
    }
}
