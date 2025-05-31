using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace GestorGastos.Web.Models
{
    public class ApplicationUser : IdentityUser
    {
        // Relación con Categorías y Entradas
        public ICollection<Categoria> Categorias { get; set; } = new List<Categoria>();
        public ICollection<Entrada> Entradas    { get; set; } = new List<Entrada>();
    }
}
