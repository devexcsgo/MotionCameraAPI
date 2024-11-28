using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

// NuGet package Microsoft.EntityFrameworkCore.SqlServer

namespace MotionCameraAPI
{
    public class LicensePlateDbContext : DbContext
    {
        public LicensePlateDbContext(DbContextOptions<LicensePlateDbContext> options) : base(options) { }
        public DbSet<LicensePlate> LicensePlate { get; set; }

    }
}



