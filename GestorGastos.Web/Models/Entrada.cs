using System;
using System.ComponentModel.DataAnnotations;

namespace GestorGastos.Web.Models
{
    public class Entrada
    {
        public int Id { get; set; }

        [Required]
        public decimal Monto { get; set; }

        public DateTime Fecha { get; set; } = DateTime.Now;
    }
}
