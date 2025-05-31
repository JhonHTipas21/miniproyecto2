using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestorGastos.Web.Data;
using GestorGastos.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace GestorGastos.Web.Services
{
    public class CategoriaService
    {
        private readonly ApplicationDbContext _db;
        public CategoriaService(ApplicationDbContext db) => _db = db;

        public Task<List<Categoria>> GetAllAsync()
            => _db.Categorias
                  .Where(c => c.Activo)
                  .ToListAsync();

        public Task<Categoria?> GetByIdAsync(int id)
            => _db.Categorias
                  .FirstOrDefaultAsync(c => c.Id == id);

        public async Task AddAsync(Categoria c)
        {
            _db.Categorias.Add(c);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateAsync(Categoria c)
        {
            _db.Categorias.Update(c);
            await _db.SaveChangesAsync();
        }

        public async Task LogicalDeleteAsync(int id)
        {
            var c = await _db.Categorias.FindAsync(id);
            if (c != null)
            {
                c.Activo = false;
                await _db.SaveChangesAsync();
            }
        }

        public async Task<decimal> GetTotalEntradasMesAsync(int year, int month)
        {
            var total = await _db.Entradas
                                 .Where(e => e.Fecha.Year == year && e.Fecha.Month == month)
                                 .SumAsync(e => (decimal?)e.Monto);
            return total ?? 0m;
        }

        public async Task<decimal> GetTotalGastosPorCategoriaMesAsync(int catId, int year, int month)
        {
            var total = await _db.Gastos
                                 .Where(g => g.CategoriaId == catId
                                          && g.Fecha.Year == year
                                          && g.Fecha.Month == month)
                                 .SumAsync(g => (decimal?)g.Monto);
            return total ?? 0m;
        }
    }
}
