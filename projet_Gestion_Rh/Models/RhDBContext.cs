using Microsoft.EntityFrameworkCore;

namespace projet_Gestion_Rh.Models
{
    public class RhDBContext : DbContext
    {
        public RhDBContext(DbContextOptions<RhDBContext> options)
    : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    => optionsBuilder.UseSqlServer("Server=DESKTOP-ASL6U64\\MSSQLSERVER1;Database=RhDB;Integrated Security=True;Trust Server Certificate=yes");




    }
}
