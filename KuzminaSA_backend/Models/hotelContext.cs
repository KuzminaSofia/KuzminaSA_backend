using KuzminaSA_backend.Models;
using NuGet.LibraryModel;
using Microsoft.EntityFrameworkCore; //

namespace KuzminaSA_backend.Models
{
    public class hotelContext : DbContext //
    {
        public hotelContext(DbContextOptions<hotelContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<hotel>().HasMany(lib => lib.room).WithMany();
        }

        public DbSet<KuzminaSA_backend.Models.guest> guest { get; set; }
        public DbSet<KuzminaSA_backend.Models.room> room { get; set; }
        public DbSet<KuzminaSA_backend.Models.hotel> hotel { get; set; } = default!;
        public DbSet<KuzminaSA_backend.Models.user> user { get; set; } = default!;

    }
}
