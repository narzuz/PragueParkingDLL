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

        /// <summary>
        /// Parks a IVehicle object on first available spot
        /// </summary>
        /// <param name="vehicle"></param>
        /// <param name="spot"></param>
        /// <returns></returns>
        public bool Park(IVehicle vehicle)
        {
            if (FindVehicle(vehicle.RegNum) != -1)
            {
                return false;
            }
            foreach (var spot in spots)
            {
                if (spot.AddVehicle(vehicle))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Parks a IVehicle object on a specific spot.
        /// </summary>
        /// <param name="vehicle"></param>
        /// <param name="spot"></param>
        /// <returns></returns>
        public bool Park(IVehicle vehicle, int spot)
        {
            if (spot < 0 || spot > (this.spots.Count))
            {
                return false;
            }
            int target = spot;
            if (FindVehicle(vehicle.RegNum) != -1)
            {
                return false;
            }
            if (this.spots[target].AddVehicle(vehicle))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Removes a vehicle from the internal list of Spot and also delivers the Vehicle object. Return null if vehicle does not exsist.
        /// </summary>
        /// <param name="regNum"></param>
        /// <returns></returns>
        public IVehicle RemoveVehicle(string regNum)
        {
            int spot = FindVehicle(regNum);
            if (spot == -1)
            {
                return null;
            }
            IVehicle vehicle = this.spots[spot].RemoveVehicle(regNum);
            return vehicle;
        }

        /// <summary>
        /// Moves a vehicle from one spot to another. Return true if the vehicle has been succesfully removed. False if fail.
        /// </summary>
        /// <param name="regNum"></param>
        /// <param name="spot"></param>
        /// <returns></returns>
        public bool MoveVehicle(string regNum, int spot)
        {
            int currentSpot = FindVehicle(regNum);
            if (currentSpot == -1)
            {
                return false;
            }
            IVehicle vehicle = this.spots[currentSpot].FindVehicle(regNum);
            if (this.spots[spot].AddVehicle(vehicle))
            {
                this.spots[currentSpot].RemoveVehicle(regNum);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Optimizes all the currently parked vehicles
        /// </summary>
        /// <returns></returns>
        public List<string> OptimizeParkingLot()
        {
            List<string> workOrders = new List<string>();
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < this.spots.Count; i++)
            {
                if (this.spots[i].GetAvailableCapacity > 0)
                {
                    for (int j = i + 1; j < this.spots.Count; j++)
                    {
                        if (this.spots[j].GetAvailableCapacity > 0 && this.spots[j].GetAvailableCapacity < this.spots[j].Capacity)
                        {
                            List<IVehicle> moveVehicles = this.spots[j].ContentClone();
                            Spot targetSpotClone = this.spots[i].CloneSpot();
                            foreach (var vehicle in moveVehicles)
                            {
                                if (targetSpotClone.AddVehicle(vehicle))
                                {
                                    this.spots[i].AddVehicle(this.spots[j].RemoveVehicle(vehicle.RegNum));
                                    sb.Append("\nVehicle " + vehicle.RegNum);
                                    sb.Append(" has been moved from spot " + (j + 1));
                                    sb.Append(" to spot " + (i + 1));


                                    workOrders.Add(sb.ToString());
                                }
                            }
                            break;
                        }
                    }
                }
            }
            return workOrders;
        }

        /// <summary>
        /// Searches for a vehicle by its registration number. Return spot number if found, returns -1 if vehicle does not exist
        /// </summary>
        /// <param name="regNum"></param>
        /// <returns></returns>
        public int FindVehicle(string regNum)
        {
            for (int i = 0; i < this.spots.Count; i++)
            {
                if (this.spots[i].FindVehicle(regNum) != null)
                {
                        int spotNum = i;
                        return spotNum;
                }
            }
            return -1;
        }

        /// <summary>
        /// To be used for printing all currently parked vehicles
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var spot in spots)
            {
                sb.Append(spot.ToString() + "\n");
            }
            return sb.ToString();
        }
    }
}
