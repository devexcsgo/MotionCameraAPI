using Microsoft.EntityFrameworkCore;
using MotionCameraAPI;

[TestClass()]
public class LicensePlateRepositoryDBTests
{
    private LicensePlateDbContext _context;
    private LicensePlateRepositoryDB _licensePlateRepository;

    [TestInitialize()]
    public void InitOnce()
    {
        var optionsBuilder = new DbContextOptionsBuilder<LicensePlateDbContext>();
        optionsBuilder.UseSqlServer(Secret.ConnectionString);

        _context = new LicensePlateDbContext(optionsBuilder.Options);

        // clean database table
        _context.Database.ExecuteSqlRaw("DELETE FROM dbo.LicensePlate");

        _licensePlateRepository = new LicensePlateRepositoryDB(_context);
    }

    [TestMethod()]
    public void AddTest()
    {
        Assert.ThrowsException<ArgumentNullException>(() =>
            _licensePlateRepository.Add(new LicensePlate { Plate = null }));
        Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
            _licensePlateRepository.Add(new LicensePlate { Plate = "" }));
    }

    [TestMethod()]
    public void GetByIdTest()
    {
        var tan = _licensePlateRepository.Add(
            new LicensePlate { Plate = "EF54321", ImagePath = "Area", Time = DateTime.UtcNow });
        var silas = _licensePlateRepository.Add(
            new LicensePlate { Plate = "GH09876", ImagePath = "Place", Time = DateTime.UtcNow });

        Assert.AreEqual(tan.Id, _licensePlateRepository.Get(tan.Id)?.Id);
        Assert.AreEqual(silas.Id, _licensePlateRepository.Get(silas.Id)?.Id);
        Assert.IsNull(_licensePlateRepository.Get(999));
    }

    [TestMethod()]
    public void GetAllTest()
    {
        _licensePlateRepository.Add(new LicensePlate { Plate = "CD67890", ImagePath = "Location", Time = DateTime.UtcNow });
        var plates = _licensePlateRepository.GetAll();

        Assert.AreEqual(1, plates.Count());
    }

    [TestMethod()]
    public void RemoveTest()
    {
        var plate = _licensePlateRepository.Add(new LicensePlate { Plate = "EF54321", ImagePath = "Area", Time = DateTime.UtcNow });

        _licensePlateRepository.Remove(plate.Id);

        Assert.IsNull(_licensePlateRepository.Get(plate.Id));
    }
}
