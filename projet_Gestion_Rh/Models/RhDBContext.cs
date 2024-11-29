using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using projet_Gestion_Rh.Migrations;
using projet_Gestion_Rh.Models;

namespace projet_Gestion_Rh.Models
{
    public class RhDBContext :IdentityDbContext     {
        public RhDBContext(DbContextOptions<RhDBContext> options)
    : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    => optionsBuilder.UseSqlServer("Server=DESKTOP-ASL6U64\\MSSQLSERVER1;Database=RhDB;Integrated Security=True;Trust Server Certificate=yes");

        public virtual DbSet<Employe> Employes { get; set; }
        public virtual DbSet<Departement> Departements { get; set; }

        public virtual DbSet<Poste> Postes { get; set; }

        public virtual DbSet<Conge> Conges { get; set; }





    }
}
