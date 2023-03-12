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

        /*
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }
        */

        public DbSet<guest> guests { get; set; } // здесь вместо book название своего класса

        public DbSet<room> rooms { get; set; } //
    }
}