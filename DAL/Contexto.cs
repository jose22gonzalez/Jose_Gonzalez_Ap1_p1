using Microsoft.EntityFrameworkCore;
using Jose_Gonzalez_Ap1_p1.Entidades;

namespace Jose_Gonzalez_Ap1_p1.DAL
{
    public class Contexto:DbContext
{
    public DbSet<Productos> Productos { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(@"Data Source=Data\Productos.db");
    }
}
}

