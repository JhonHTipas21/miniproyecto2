using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using GestorGastos.Web.Models;
using GestorGastos.Web.Services;

namespace GestorGastos.Web.Controllers
{
    public class EntradaController : Controller
    {
        private readonly EntradaService _eSvc;
        public EntradaController(EntradaService eSvc) => _eSvc = eSvc;

        public async Task<IActionResult> Index()
        {
            var list = await _eSvc.GetAllAsync();
            return View(list);
        }

        public IActionResult Create() => View();

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Entrada e)
        {
            if (!ModelState.IsValid) return View(e);
            await _eSvc.AddAsync(e);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _eSvc.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
