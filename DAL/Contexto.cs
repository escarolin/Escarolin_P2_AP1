using Microsoft.EntityFrameworkCore;
using Escarolin_P2_AP1.Entidades;


namespace Escarolin_P2_AP1.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Tareas> Tareas { get; set; }
        public DbSet<Proyectos> Proyectos { get; set; }
       
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source = Data\Proyecto.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tareas>().HasData(new Tareas { TareaId = 1, DescripcionT = "Analisis" });
            modelBuilder.Entity<Tareas>().HasData(new Tareas { TareaId = 2, DescripcionT = "Diseño " });
            modelBuilder.Entity<Tareas>().HasData(new Tareas { TareaId = 3, DescripcionT= "Programación Aplicada" });
        
        }
    }
}