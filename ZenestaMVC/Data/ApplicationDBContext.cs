using Microsoft.EntityFrameworkCore;

using ZenestaMVC.Models.Entity;

namespace ZenestaMVC.Data
{
    public class ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : DbContext(options)
    {
        /*
        public DbSet<Student> Students { get; set; }
        public DbSet<Book> Books { get; set; }
        */
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<PredictionBatch> PredictionBatches { get; set; } = null!;
        public DbSet<Prediction> Predictions { get; set; } = null!;
        public DbSet<PredictionResult> PredictionResults { get; set; } = null!;
        public DbSet<PredictionImage> PredictionImages { get; set; } = null!;
    }
}
