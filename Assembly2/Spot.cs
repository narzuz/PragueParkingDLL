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
        private List<IVehicle> vehicles;
        private int capacity;
        private int GetOccupiedCapacity { get => GetOccupiedCapacityMethod(); }

        int GetOccupiedCapacityMethod()
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

        bool AddVehicle(IVehicle vehicle)
        {
            int vehicleSize = (int)vehicle.Type;
            if (vehicleSize < GetAvailableCapacity())
            {
                vehicles.Add(vehicle);
                return true;
            }
            return false;
        }
        
        IVehicle RemoveVehicle(string regNum)
        {
            foreach (var vehicle in vehicles)
            {
                if(vehicle.RegNum == regNum)
                {
                    vehicles.Remove(vehicle);
                    return vehicle;
                }
            }
            return null;
        }

        bool FindVehicle(string regNum)
        {
            foreach (var vehicle in vehicles)
            {
                if(vehicle.RegNum == regNum)
                {
                    return true;
                }
            }
            return false;
        }

        int GetAvailableCapacity()
        {
            int availableCapacity = (this.capacity - GetOccupiedCapacity);
            return availableCapacity;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
