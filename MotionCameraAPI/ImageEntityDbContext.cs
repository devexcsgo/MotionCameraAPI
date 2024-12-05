using Microsoft.EntityFrameworkCore;

namespace MotionCameraAPI
{
    public class ImageEntityDbContext : DbContext
    {
        public ImageEntityDbContext(DbContextOptions<ImageEntityDbContext> options)
            : base(options)
        {
        }

        public DbSet<ImageEntity> Images { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ImageEntity>(entity =>
            {
                entity.ToTable("images");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.ImageData).HasColumnName("image_data");
                entity.Property(e => e.Timestamp).HasColumnName("timestamp").HasDefaultValueSql("getdate()");
            });
        }
    }
}
