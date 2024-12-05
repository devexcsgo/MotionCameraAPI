using MotionCameraAPI;
using Microsoft.EntityFrameworkCore;
namespace MotionCameraAPI
{
    public class LicensePlateRepositoryDB
    {
        private readonly LicensePlateDbContext _context;

        public LicensePlateRepositoryDB(LicensePlateDbContext dbContext)
        {
            _context = dbContext;
        }

        public LicensePlate Add(LicensePlate licensePlate)
        {
            licensePlate.ValidatePlate();
            licensePlate.Id = 0;
            _context.LicensePlate.Add(licensePlate);
            _context.SaveChanges();
            return licensePlate;
        }

        public LicensePlate? Get(int id)
        {
            return _context.LicensePlate.FirstOrDefault(lp => lp.Id == id);
        }

        public IEnumerable<LicensePlate> GetAll()
        {
            //Makes a Copy of the list
            IQueryable<LicensePlate> query = _context.LicensePlate.ToList().AsQueryable();
            return query;
        }

        public LicensePlate? Remove(int id)
        {
            LicensePlate? licensePlate = Get(id);
            if (licensePlate is null)
            {
                return null;
            }
            _context.LicensePlate.Remove(licensePlate);
            _context.SaveChanges();
            return licensePlate;
        }
    }
}