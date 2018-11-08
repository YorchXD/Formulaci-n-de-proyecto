using Microsoft.EntityFrameworkCore;

namespace SimRend.Models
{
    public class FondoContext : DbContext
    {
        public FondoContext (DbContextOptions<FondoContext> options)
            : base(options)
        {
        }

        public DbSet<SimRend.Models.Solicitud> Solicitud { get; set; }
    }
}