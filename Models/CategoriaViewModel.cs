namespace GestorGastos.Web.Models
{
    public class CategoriaViewModel
    {
        // Identificador de la categoría
        public int Id { get; set; }

        // Título, p.ej. "Alimentación"
        public string Titulo { get; set; } = null!;

        // Descripción opcional
        public string? Descripcion { get; set; }

        // Porcentaje máximo asignado
        public int PorcentajeMaximo { get; set; }

        // Valores calculados para mostrar en el índice
        public decimal GastoActual  { get; set; }
        public decimal MaxPermitido { get; set; }
    }
}
