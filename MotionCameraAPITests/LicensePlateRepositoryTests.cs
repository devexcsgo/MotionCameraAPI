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
    public class LicensePlateRepositoryTests
    {
		[TestMethod()]
		public void MockDataTest()
		{
			LicensePlateRepository repository = new LicensePlateRepository();
			repository.MockData(); // Puts the two licensePlate objs into the repository
            // Assert
			Assert.AreEqual(2, repository.GetAll().Count());

            repository.MockData(); // Mockdata can only put licensePlate objs into repository, if it is empty
			Assert.AreEqual(2, repository.GetAll().Count());
		}

		[TestMethod()]
        public void AddLicensePlateTest()
        {
            ///<Summary>
            ///
            ///</Summary>
            // Arrange: Create repository & license plates
            LicensePlateRepository repository = new LicensePlateRepository();
            LicensePlate licensePlateTest = new LicensePlate()
            {
                Plate = "AB12345"
            };
            // Act: Add license plates to repository
            repository.Add(licensePlateTest);

            // Assert: Check if the license plate matches
            Assert.AreEqual("AB12345", licensePlateTest.Plate);
            // Assert: Check how many license plates are in the list
            Assert.AreEqual(1, repository.GetAll().Count());
        }

        [TestMethod()]
        public void GetByIdTest()
        {
			// Arrange: Create repository & license plates
			LicensePlateRepository repository = new LicensePlateRepository();
			LicensePlate licensePlateTest1 = new LicensePlate() { Plate = "AB12345" };
			LicensePlate licensePlateTest2 = new LicensePlate() { Plate = "CD67890" };

            repository.Add(licensePlateTest1);
			repository.Add(licensePlateTest2);

            Assert.AreEqual(licensePlateTest1, repository.Get(1));
            Assert.AreEqual(licensePlateTest2, repository.Get(2));
            Assert.IsNull(repository.Get(3)?.Id); // Kontrollerer for ugyldigt ID
        }

        [TestMethod()]
        public void GetAllTest()
        {
            // Arrange: Create repostiroy & license plates
            LicensePlateRepository repository = new LicensePlateRepository();
            LicensePlate licensePlate1 = new LicensePlate() { Plate = "CD14567" };
            LicensePlate licensePlate2 = new LicensePlate() { Plate = "KP15325" };

            // Act: Add license plates to repository
            repository.Add(licensePlate1);
            repository.Add(licensePlate2);
            // Assert: Check how many licenseplates are in repository
            Assert.AreEqual(2, repository.GetAll().Count());
        }

        [TestMethod()]
        public void RemoveTest()
        {
			// Arrange: Create repostiroy & license plates
			LicensePlateRepository repository = new LicensePlateRepository();
			LicensePlate licensePlate1 = new LicensePlate() { Plate = "CD14567" };
			LicensePlate licensePlate2 = new LicensePlate() { Plate = "KP15325" };

			// Act: Add license plates to repository
			repository.Add(licensePlate1);
			repository.Add(licensePlate2);
            // Act: Remove license plate with the ID '1' (licensePlate1)
            repository.Remove(1);

            Assert.AreEqual(1, repository.GetAll().Count());
			Assert.IsNull(repository.Get(1)?.Id);
            Assert.IsNull(repository.Remove(222)); // Check if you remove an Id that does not exist
        }
    }
}