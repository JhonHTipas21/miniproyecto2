using Microsoft.EntityFrameworkCore;
using GestorGastos.Web.Models;

namespace GestorGastos.Web.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Gasto> Gastos { get; set; }
        public DbSet<Entrada> Entradas { get; set; }
    }
}
