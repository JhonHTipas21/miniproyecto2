using System;
using System.ComponentModel.DataAnnotations;

namespace GestorGastos.Web.Models
{
    public class Entrada
    {
        public int Id { get; set; }

        [Required, Range(0.01, double.MaxValue, ErrorMessage = "El monto debe ser positivo")]
        public decimal Monto { get; set; }

        [Required, DataType(DataType.Date)]
        public DateTime Fecha { get; set; }
    }
}
