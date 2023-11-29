using Microsoft.EntityFrameworkCore;

namespace projet_Gestion_Rh.Models
{
    public class RhDBContext : DbContext
    {
        public RhDBContext(DbContextOptions<RhDBContext> options)
    : base(options)
        {
        }

        public DbSet<Employe> Employe { get; set; }


    }
}
