using Microsoft.EntityFrameworkCore;


namespace Escarolin_P2_AP1
{
    public class Contexto : DbContext
    {
            // public DbSet<Productos> Productos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source= Data\Proyecto.db");
        }

     
      protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}