using Microsoft.VisualStudio.TestTools.UnitTesting;
using MotionCameraAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotionCameraAPI.Tests
{
    [TestClass()]
    public class LicensePlateTests
    {
        [TestMethod()]
        public void ValidatePlateTest()
        {
            // Arrange: Create a Danish license plate with a name that is too short (6 characters)
            LicensePlate licensePlateShort = new LicensePlate()
            {
                Id = 1,
                Plate = "NO1234"
            };
            // Arrange: Create a Danish license plate with a name that is too long (8 characters)
            LicensePlate licensePlateLong = new LicensePlate()
            {
                Id = 2,
                Plate = "YE123456"
            };
            // Arrange: Create a Danish license plate with a name that is null
            LicensePlate licensePlateNull = new LicensePlate()
            {
                Id = 3,
                Plate = null
            };
            // Expect a 'ArgumentOutOfRangeException'
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => licensePlateShort.ValidatePlate());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => licensePlateLong.ValidatePlate());
            // Expect a' ArgumentNullException'
            Assert.ThrowsException<ArgumentNullException>(() => licensePlateNull.ValidatePlate());
        }
    }
}