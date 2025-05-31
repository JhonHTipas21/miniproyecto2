using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GestorGastos.Web.Models;
using GestorGastos.Web.Services;

namespace GestorGastos.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly GastoService _gastoSvc;
        public HomeController(GastoService gastoSvc) => _gastoSvc = gastoSvc;

        public async Task<IActionResult> Index()
        {
            var vm = new DashboardViewModel();
            DateTime today = DateTime.Today;

            // 1) Gastos atrasados
            vm.OverdueTotal = await _gastoSvc.GetTotalByPeriodAsync(DateTime.MinValue, today.AddDays(-1));
            vm.OverdueCount = (await _gastoSvc.GetAllAsync()).Count(g => g.Fecha < today);

            // 2) Vence hoy
            vm.DueTodayTotal = await _gastoSvc.GetTotalByPeriodAsync(today, today);
            vm.DueTodayCount = (await _gastoSvc.GetAllAsync()).Count(g => g.Fecha == today);

            // 3) Próximos 7 días
            vm.WeeklyTotal = await _gastoSvc.GetTotalByPeriodAsync(today.AddDays(1), today.AddDays(7));
            vm.WeeklyCount = (await _gastoSvc.GetAllAsync())
                                 .Count(g => g.Fecha > today && g.Fecha <= today.AddDays(7));

            // 4) Datos para el gráfico (últimos 6 meses)
            for (int i = 5; i >= 0; i--)
            {
                var month = today.AddMonths(-i);
                var start = new DateTime(month.Year, month.Month, 1);
                var end   = new DateTime(month.Year, month.Month, DateTime.DaysInMonth(month.Year, month.Month));

                vm.Labels.Add(month.ToString("MMM yy"));
                vm.Data.Add(await _gastoSvc.GetTotalByPeriodAsync(start, end));
            }

            ViewData["Title"] = "Finanzas";
            return View(vm);
        }
    }
}
