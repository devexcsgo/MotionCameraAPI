using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

// NuGet package Microsoft.EntityFrameworkCore.SqlServer

namespace MotionCameraAPI
{
    public class LicensePlateDbContext : DbContext
    {
        public DbSet<LicensePlate> LicensePlates { get; set; }
        public DbSet<ImageEntity> Images { get; set; }

        public LicensePlateDbContext(DbContextOptions<LicensePlateDbContext> options) : base(options) { }
        public DbSet<LicensePlate> LicensePlate { get; set; }

    }


}
