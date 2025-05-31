using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestorGastos.Web.Data;
using GestorGastos.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace GestorGastos.Web.Services
{
    public class GastoService
    {
        private readonly ApplicationDbContext _db;
        public GastoService(ApplicationDbContext db) => _db = db;

        public Task<List<Gasto>> GetAllAsync()
            => _db.Gastos.Include(g => g.Categoria)
                         .OrderByDescending(g => g.Fecha)
                         .ToListAsync();

        public Task<Gasto?> GetByIdAsync(int id)
            => _db.Gastos.Include(g => g.Categoria)
                         .FirstOrDefaultAsync(g => g.Id == id);

        public async Task AddAsync(Gasto g)
        {
            _db.Gastos.Add(g);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateAsync(Gasto g)
        {
            _db.Gastos.Update(g);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var g = await _db.Gastos.FindAsync(id);
            if (g != null)
            {
                _db.Gastos.Remove(g);
                await _db.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Suma los gastos cuya Fecha está entre start y end (inclusive).
        /// </summary>
        public async Task<decimal> GetTotalByPeriodAsync(DateTime start, DateTime end)
        {
            var total = await _db.Gastos
                                 .Where(g => g.Fecha >= start && g.Fecha <= end)
                                 .SumAsync(g => (decimal?)g.Monto);
            return total ?? 0m;
        }
    }
}
