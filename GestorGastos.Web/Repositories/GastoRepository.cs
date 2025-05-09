using System.Collections.Generic;
using System.Threading.Tasks;
using GestorGastos.Web.Models;
using GestorGastos.Web.Data;
using Microsoft.EntityFrameworkCore;

namespace GestorGastos.Web.Repositories
{
    public class GastoRepository : IGastoRepository
    {
        private readonly ApplicationDbContext _context;

        public GastoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Gasto>> GetAllAsync() =>
            await _context.Gastos.Include(g => g.Categoria).ToListAsync();

        public async Task<Gasto?> GetByIdAsync(int id) =>
            await _context.Gastos.Include(g => g.Categoria).FirstOrDefaultAsync(g => g.Id == id);

        public async Task AddAsync(Gasto gasto)
        {
            _context.Gastos.Add(gasto);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Gasto gasto)
        {
            _context.Gastos.Update(gasto);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var gasto = await GetByIdAsync(id);
            if (gasto != null)
            {
                _context.Gastos.Remove(gasto);
                await _context.SaveChangesAsync();
            }
        }
    }
}
