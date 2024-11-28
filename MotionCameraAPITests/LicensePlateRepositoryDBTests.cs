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
		private static LicensePlateDbContext _context;
		private static ILicensePlateRepository _licensePlateRepository;
		private readonly LicensePlate _licensePlate1 = new() { Plate = "AB12345" };

		// This Initialization is so the database for lincens-plates is used for every test
		[TestInitialize()]
		public void InitOnce()
		{
			var optionsBuilder = new DbContextOptionsBuilder<LicensePlateDbContext>();
			optionsBuilder.UseSqlServer(Secret.ConnectionString);
			// connection string structure

			LicensePlateDbContext _context = new LicensePlateDbContext(optionsBuilder.Options);

			// clean database table: remove all rows
			_context.Database.ExecuteSqlRaw("TRUNCATE TABLE dbo.LicensePlate");
			_licensePlateRepository = new LicensePlateRepositoryDB(_context);
		}

		//[TestMethod()]
		//public void LicensePlateRepositoryDBTest()
		//{
		//    Assert.Fail();
		//}

		[TestMethod()]
		public void AddTest()
		{
			// Assert
			Assert.ThrowsException<ArgumentNullException>(
				() => _licensePlateRepository.Add(new LicensePlate { Plate = null }));
			Assert.ThrowsException<ArgumentOutOfRangeException>(
				() => _licensePlateRepository.Add(new LicensePlate { Plate = "" }));
		}

		[TestMethod()]
		public void GetByIdTest()
		{
			_licensePlateRepository.Add(new LicensePlate { Plate = "CD67890", ImagePath = "Location", Time = DateTime.Parse("2024-11-28T08:56:56.962Z") });

			LicensePlate tan = _licensePlateRepository.Add
				(new LicensePlate { Plate = "EF54321", ImagePath = "Area", Time = DateTime.Parse("2024-11-28T08:56:57.962Z") });
			LicensePlate silas = _licensePlateRepository.Add
				(new LicensePlate { Plate = "GH09876", ImagePath = "Place", Time = DateTime.Parse("2024-11-28T08:56:58.962Z") });

			// Assert
			Assert.AreEqual(tan, _licensePlateRepository.Get(2));
			Assert.AreEqual(silas, _licensePlateRepository.Get(3));
			Assert.IsNull(_licensePlateRepository.Get(4));
		}

		[TestMethod()]
		public void GetAllTest()
		{
			_licensePlateRepository.Add(new LicensePlate { Plate = "CD67890", ImagePath = "Location", Time = DateTime.Parse("2024-11-28T08:56:56.962Z") });

			LicensePlate tan = _licensePlateRepository.Add
				(new LicensePlate { Plate = "EF54321", ImagePath = "Area", Time = DateTime.Parse("2024-11-28T08:56:57.962Z") });
			LicensePlate silas = _licensePlateRepository.Add
				(new LicensePlate { Plate = "GH09876", ImagePath = "Place", Time = DateTime.Parse("2024-11-28T08:56:58.962Z") });
			LicensePlate rasmus = _licensePlateRepository.Add
				(new LicensePlate { Plate = "IJ13579", ImagePath = "Place", Time = DateTime.Parse("2024-11-28T08:56:59.962Z") });
			LicensePlate Zimon = _licensePlateRepository.Add
				(new LicensePlate { Plate = "kl24680", ImagePath = "Place", Time = DateTime.Parse("2024-11-28T08:57:01.962Z") });

			// Assert
			IEnumerable<LicensePlate> All = _licensePlateRepository.GetAll();
			Assert.AreEqual(5, All.Count());
		}

		[TestMethod()]
		public void RemoveTest()
		{
			_licensePlateRepository.Add(new LicensePlate { Plate = "CD67890", ImagePath = "Location", Time = DateTime.Parse("2024-11-28T08:56:56.962Z") });

			LicensePlate tan = _licensePlateRepository.Add
						 (new LicensePlate { Plate = "EF54321", ImagePath = "Area", Time = DateTime.Parse("2024-11-28T08:56:57.962Z") });
			LicensePlate silas = _licensePlateRepository.Add
						 (new LicensePlate { Plate = "GH09876", ImagePath = "Place", Time = DateTime.Parse("2024-11-28T08:56:58.962Z") });
			LicensePlate rasmus = _licensePlateRepository.Add
				(new LicensePlate { Plate = "IJ13579", ImagePath = "Place", Time = DateTime.Parse("2024-11-28T08:56:59.962Z") });

			// Removes id 1.
			_licensePlateRepository.Remove(3);

			// Assert
			Assert.IsNull(_licensePlateRepository.Get(3));
			Assert.AreEqual(rasmus.Id, 4);
			IEnumerable<LicensePlate> All = _licensePlateRepository.GetAll();
			Assert.AreEqual(3, All.Count());
		}
	}
}