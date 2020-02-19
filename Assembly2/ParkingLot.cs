using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assembly1;

namespace Assembly2
{

    /// <summary>
    /// Parking lot with an assigned number of parking spots and an assigned parking capacity. Default size is 100, default capacity is 4.
    /// </summary>
    public class ParkingLot
    {
        private List<Spot> spots = new List<Spot>();
        private int size;
        private int capacity;

        public ParkingLot()
        {
            this.size = 100;
            this.capacity = 4;
            InitializeSpots(this.size, this.capacity);
        }
        public ParkingLot(int size)
        {
            this.size = size;
            this.capacity = 4;
            InitializeSpots(this.size, this.capacity);
        }
        public ParkingLot(int size, int capacity)
        {
            this.size = size;
            this.capacity = capacity;
            InitializeSpots(this.size, this.capacity);
        }

        /// <summary>
        /// Adds and initializes several spots at once.
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="capacity"></param>
        /// <returns></returns>
        public bool InitializeSpots(int amount, int capacity)
        {
            int oldAmount = this.spots.Count;
            int newAmount = oldAmount + amount;
            for (int i = 0; i < amount; i++)
            {
                AddSpot(capacity);
            }
            if (this.spots.Count >= newAmount)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// Adds one individual spot to the parkinglot.
        /// </summary>
        /// <param name="capacity"></param>
        /// <returns></returns>
        public bool AddSpot(int capacity) 
        {
            this.spots.Add(new Spot(capacity));
            if (this.spots.Count > 1)
            {
                return true;
            }
            return false;
        }

        public bool Park(IVehicle vehicle)
        {
            
        }

        public int Park(IVehicle vehicle, int spot)
        {

        }

        public bool MoveVehicle(string regNum, Spot spot)
        {

        }

        public int FindVehicle(string regNum)
        {

        }

        public List<string> OptimizeParkingLot()
        {

        }

        IVehicle RemoveVehicle()
        {

        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
