using System.Collections.Generic;

namespace GestorGastos.Web.Models
{
    public class DashboardViewModel
    {
        public decimal OverdueTotal   { get; set; }
        public int     OverdueCount   { get; set; }
        public decimal DueTodayTotal  { get; set; }
        public int     DueTodayCount  { get; set; }
        public decimal WeeklyTotal    { get; set; }
        public int     WeeklyCount    { get; set; }

        // Para el gráfico de los últimos 6 meses
        public List<string>  Labels { get; set; } = new();
        public List<decimal> Data   { get; set; } = new();
    }
}
