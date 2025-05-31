using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GestorGastos.Web.Models
{
    public class Categoria
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Titulo { get; set; } = null!;

        public string? Descripcion { get; set; }

        [Display(Name = "Porcentaje máximo por mes")]
        [Range(0,100, ErrorMessage = "Debe ser entre 0 y 100")]
        public int PorcentajeMaximo { get; set; }

        // Eliminación lógica
        public bool Activo { get; set; } = true;

        public ICollection<Gasto> Gastos { get; set; } = new List<Gasto>();
    }
}
