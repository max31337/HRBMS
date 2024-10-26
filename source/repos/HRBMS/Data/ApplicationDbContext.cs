using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace HRBMS.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

        public DbSet<Reservation> Reservations { get; set; }
    }
}
