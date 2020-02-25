using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assembly1;
using Assembly2;

namespace ASSEMBLYREEMSTESTS
{
    [TestClass]
    public class UnitTest1
    {
        [DataRow("REEE", Assembly1.Type.Car, 30)]
        [DataRow("EREE", Assembly1.Type.Car, 1)]
        [DataRow("EERE", Assembly1.Type.Mc, 60)]
        [DataTestMethod]
        public void TestParkingAtSpot(string regNum, Assembly1.Type type, int sputter)
        {
            ParkingLot lot = new ParkingLot();
            IVehicle vehicle = new Vehicle(regNum, type);
            Assert.IsTrue(lot.Park(vehicle, sputter));
        }

        [DataRow("REEE", Assembly1.Type.Car, 50)]
        [DataRow("EREE", Assembly1.Type.Car, 49)]
        [DataRow("EERE", Assembly1.Type.Mc, 32)]
        [DataTestMethod]
        public void TestFindVehicle(string regNum, Assembly1.Type type, int spot)
        {
            ParkingLot lot = new ParkingLot();
            IVehicle vehicle = new Vehicle(regNum, type);

            lot.Park(vehicle, spot);
            int expected = spot;
            int actual = lot.FindVehicle(regNum);
            Assert.AreEqual(expected, actual);
        }


        [DataRow("REEE", Assembly1.Type.Car, 15)]
        [DataRow("EREE", Assembly1.Type.Car, 33)]
        [DataRow("EERE", Assembly1.Type.Mc, 60)]
        [DataTestMethod]
        public void TestMoveVehicle(string regNum, Assembly1.Type type, int sputter)
        {
            ParkingLot lot = new ParkingLot();
            IVehicle vehicle = new Vehicle(regNum, type);

            lot.Park(vehicle);

            Assert.IsTrue(lot.MoveVehicle(regNum, sputter));

        }


    }
}
