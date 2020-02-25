using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assembly1;
using Assembly2;

namespace TestFrontEnd
{
    /// <summary>
    /// EXTREMELY ALPHA TESTING FILE, DONT LOOK AT IT. ITS DISGUSTING
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            ParkingLot pl = new ParkingLot();

            IVehicle vehicle = new Vehicle("ABC123", Assembly1.Type.Car);
            IVehicle vehicle2 = new Vehicle("VEH2", Assembly1.Type.Mc);
            IVehicle vehicle3 = new Vehicle("VEH3", Assembly1.Type.Mc);
            IVehicle vehicle4 = new Vehicle("LONELYBIKE", Assembly1.Type.Mc);
            IVehicle vehicle5 = new Vehicle("BIGCAR", Assembly1.Type.Car);

            pl.Park(vehicle);
            pl.Park(vehicle2);
            pl.Park(vehicle3);
            pl.Park(vehicle4, 50);
            pl.Park(vehicle5, 20);
            Console.WriteLine(pl.ToString());
            Console.WriteLine("click to remove das big bigcar");
            Console.ReadKey();
            Console.Clear();

            IVehicle vhremove = pl.RemoveVehicle("BIGCAR");
            Console.WriteLine("we have removed {0}", vhremove.RegNum);
            Console.WriteLine();
            Console.WriteLine("click to show pl again");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine(pl.ToString());
            Console.WriteLine();
            Console.WriteLine("press a key to optimize all :)");
            Console.ReadKey();
            Console.Clear();
            foreach(string workorder in pl.OptimizeParkingLot())
            {
                Console.WriteLine(workorder);
            }
            Console.WriteLine(pl.ToString());
            Console.WriteLine("press a key to park a new bike boy");
            Console.ReadKey();
            Console.Clear();
            IVehicle vehicle6 = new Vehicle("LONELYBIKE2", Assembly1.Type.Mc);
            pl.Park(vehicle6, 25);
            Console.WriteLine(pl.ToString());
            Console.WriteLine("press a key to optimize, moving bikes together");
            Console.ReadKey();
            Console.Clear();
            foreach (var order in pl.OptimizeParkingLot())
            {
                Console.WriteLine(order);
            }
            Console.WriteLine();
            Console.WriteLine(pl.ToString());
            Console.WriteLine("press a key to test moving lonelybike to a new slot");
            Console.ReadKey();
            Console.Clear();
            pl.MoveVehicle("LONELYBIKE", 50);
            Console.WriteLine(pl.ToString());
            Console.ReadKey();
        }
    }
}
