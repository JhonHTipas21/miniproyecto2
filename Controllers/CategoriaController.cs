using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GestorGastos.Web.Models;
using GestorGastos.Web.Services;

namespace GestorGastos.Web.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly CategoriaService _catSvc;
        public CategoriaController(CategoriaService catSvc) => _catSvc = catSvc;

        // GET: Categoria
        public async Task<IActionResult> Index()
        {
            var cats = await _catSvc.GetAllAsync();
            int year = DateTime.Now.Year, month = DateTime.Now.Month;
            decimal entradasMes = await _catSvc.GetTotalEntradasMesAsync(year, month);

            // Construyo la lista con await en foreach
            var vm = new List<CategoriaViewModel>();
            foreach (var c in cats)
            {
                var gastoActual = await _catSvc.GetTotalGastosPorCategoriaMesAsync(c.Id, year, month);
                vm.Add(new CategoriaViewModel
                {
                    Id               = c.Id,
                    Titulo           = c.Titulo,
                    Descripcion      = c.Descripcion,
                    PorcentajeMaximo = c.PorcentajeMaximo,
                    GastoActual      = gastoActual,
                    MaxPermitido     = entradasMes * c.PorcentajeMaximo / 100
                });
            }

            return View(vm);
        }

        // GET: Categoria/Create
        public IActionResult Create()
            => View();

        // POST: Categoria/Create
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Categoria c)
        {
            if (!ModelState.IsValid)
                return View(c);

            await _catSvc.AddAsync(c);
            return RedirectToAction(nameof(Index));
        }

        // GET: Categoria/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var c = await _catSvc.GetByIdAsync(id);
            if (c == null)
                return NotFound();

            return View(c);
        }

        // POST: Categoria/Edit/5
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Categoria c)
        {
            if (id != c.Id)
                return BadRequest();

            if (!ModelState.IsValid)
                return View(c);

            await _catSvc.UpdateAsync(c);
            return RedirectToAction(nameof(Index));
        }

        // POST: Categoria/Delete/5
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _catSvc.LogicalDeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
