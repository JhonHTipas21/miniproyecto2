using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestorGastos.Web.Models
{
    public class Gasto
    {
        public int Id { get; set; }

        [Required]
        public decimal Monto { get; set; }

        [Required]
        public DateTime Fecha { get; set; }

        public string? Descripcion { get; set; }

        [ForeignKey("Categoria")]
        public int CategoriaId { get; set; }

        public Categoria Categoria { get; set; }
    }
}
