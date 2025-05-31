using System;
using System.ComponentModel.DataAnnotations;

namespace GestorGastos.Web.Models
{
    public class Gasto
    {
        public int Id { get; set; }

        [Required, Range(0.01, double.MaxValue, ErrorMessage = "El monto debe ser positivo")]
        public decimal Monto { get; set; }

        [Required, DataType(DataType.Date)]
        public DateTime Fecha { get; set; }

        [StringLength(250)]
        public string? Descripcion { get; set; }

        [Display(Name = "Categoría")]
        [Required(ErrorMessage = "La categoría es obligatoria")]
        public int CategoriaId { get; set; }

        public Categoria Categoria { get; set; } = null!;
    }
}
