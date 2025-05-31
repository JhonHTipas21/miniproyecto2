using GestorGastos.Web.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GestorGastos.Web.Data
{
    public class ApplicationDbContext 
        : IdentityDbContext<ApplicationUser>            // Hereda de IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Tus entidades de dominio
        public DbSet<Categoria> Categorias { get; set; } = null!;
        public DbSet<Gasto>     Gastos      { get; set; } = null!;
        public DbSet<Entrada>   Entradas    { get; set; } = null!;
    }
}
