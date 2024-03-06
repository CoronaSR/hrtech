using HR_Tech.Models;
using Microsoft.EntityFrameworkCore;
namespace HR_Tech.Data {
    public class HRContextDB(DbContextOptions<HRContextDB> options) : DbContext(options) {
        public DbSet<Empleados> Empleados { get; set; }
            public DbSet<Solicitud> Solicitud { get; set; }
            public DbSet<Usuarios> Usuarios { get; set; }

            protected override void OnModelCreating(ModelBuilder modelBuilder) {
                modelBuilder.Entity<Empleados>().ToTable("Empleados");
                modelBuilder.Entity<Solicitud>().ToTable("Solicitud");
                modelBuilder.Entity<Usuarios>().ToTable("Usuarios");
            }
        }
    }
