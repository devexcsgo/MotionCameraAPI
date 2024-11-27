using MotionCameraAPI;
using Microsoft.EntityFrameworkCore;
namespace MoviesRepositoryLib
{
    public class LicensePlateRepositoryDB : IMoviesRepository
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
            _context.LicensePlates.Add(licensePlate);
            _context.SaveChanges();
            return licensePlate;
        }

        public LicensePlate? Get(int id)
        {
            return _context.LicensePlates.FirstOrDefault(lp => lp.Id == id);
        }

        public IEnumerable<LicensePlate> GetAll()
        {
            //Makes a Copy of the list
            IQueryable<LicensePlate> query = _context.LicensePlates.ToList().AsQueryable();
            return query;
        }

        public LicensePlate? Remove(int id)
        {
            LicensePlate? licensePlate = Get(id);
            if (licensePlate is null)
            {
                return null;
            }
            _context.LicensePlates.Remove(licensePlate);
            _context.SaveChanges();
            return licensePlate;
        }
    }
}