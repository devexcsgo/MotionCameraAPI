using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
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
    public class LicensePlateRepositoryDBTests
    {
        private const bool useDatabase = true;
        private static LicensePlateDbContext _context;
        private static ILicensePlateRepository _licensePlateRepository;
        private readonly LicensePlate _licensePlate1 = new() { Plate = "AC12345" };

        [ClassInitialize]
        public static void InitOnce(TestContext context)
        {
            if (useDatabase)
            {
                var optionsBuilder = new DbContextOptionsBuilder<LicensePlateDbContext>();
				optionsBuilder.UseSqlServer(Secret.ConnectionString);
				// connection string structure

				LicensePlateDbContext _context = new LicensePlateDbContext(optionsBuilder.Options);

				// clean database table: remove all rows
				_context.Database.ExecuteSqlRaw("TRUNCATE TABLE dbo.LicensePlate");
                _licensePlateRepository = new LicensePlateRepositoryDB(_context);
            }
            else
            {
                _licensePlateRepository = new LicensePlateRepository();
            }
        }

        //[TestMethod()]
        //public void LicensePlateRepositoryDBTest()
        //{
        //    Assert.Fail();
        //}

        [TestMethod()]
        public void AddTest()
        {
            _licensePlateRepository.Add(new LicensePlate { Plate = "CD67890" });
            LicensePlate tan = _licensePlateRepository.Add(new LicensePlate { Plate = "EF54321" });

            // Assert
            Assert.IsTrue(tan.Id >= 0);
            IEnumerable<LicensePlate> All = _licensePlateRepository.GetAll();
            Assert.AreEqual(2, All.Count());

            Assert.ThrowsException<ArgumentNullException>(
                () => _licensePlateRepository.Add(new LicensePlate { Plate = null }));
            Assert.ThrowsException<ArgumentOutOfRangeException>(
                () => _licensePlateRepository.Add(new LicensePlate { Plate = "" }));
        }

        //[TestMethod()]
        //public void GetTest()
        //{
        //    Assert.Fail();
        //}

        //[TestMethod()]
        //public void GetAllTest()
        //{
        //    Assert.Fail();
        //}

        //[TestMethod()]
        //public void RemoveTest()
        //{
        //    Assert.Fail();
        //}
    }
}