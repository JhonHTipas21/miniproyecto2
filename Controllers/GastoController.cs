using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;
using GestorGastos.Web.Models;
using GestorGastos.Web.Services;

namespace GestorGastos.Web.Controllers
{
    public class GastoController : Controller
    {
        private readonly GastoService _gSvc;
        private readonly CategoriaService _cSvc;

        public GastoController(GastoService gSvc, CategoriaService cSvc)
        {
            _gSvc = gSvc;
            _cSvc = cSvc;
        }

        public async Task<IActionResult> Index()
        {
            var list = await _gSvc.GetAllAsync();
            return View(list);
        }

        public async Task<IActionResult> Create()
        {
            var cats = await _cSvc.GetAllAsync();
            ViewBag.Categorias = new SelectList(cats, "Id", "Titulo");
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Gasto gasto)
        {
            if (!ModelState.IsValid)
            {
                var cats = await _cSvc.GetAllAsync();
                ViewBag.Categorias = new SelectList(cats, "Id", "Titulo", gasto.CategoriaId);
                return View(gasto);
            }
            await _gSvc.AddAsync(gasto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var g = await _gSvc.GetByIdAsync(id);
            if (g == null) return NotFound();
            var cats = await _cSvc.GetAllAsync();
            ViewBag.Categorias = new SelectList(cats, "Id", "Titulo", g.CategoriaId);
            return View(g);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Gasto gasto)
        {
            if (id != gasto.Id) return BadRequest();
            if (!ModelState.IsValid)
            {
                var cats = await _cSvc.GetAllAsync();
                ViewBag.Categorias = new SelectList(cats, "Id", "Titulo", gasto.CategoriaId);
                return View(gasto);
            }
            await _gSvc.UpdateAsync(gasto);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _gSvc.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
