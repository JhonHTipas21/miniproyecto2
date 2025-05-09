using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GestorGastos.Web.Models
{
    public class Categoria
    {
        public int Id { get; set; }

        [Required]
        public string Titulo { get; set; }

        public string? Descripcion { get; set; }

        [Range(0, 100)]
        public decimal PorcentajeMaximo { get; set; }

        public List<Gasto> Gastos { get; set; } = new();
    }
}
