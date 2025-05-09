using System.Collections.Generic;
using System.Threading.Tasks;
using GestorGastos.Web.Models;
using GestorGastos.Web.Data;
using Microsoft.EntityFrameworkCore;

namespace GestorGastos.Web.Repositories
{
    public class EntradaRepository : IEntradaRepository
    {
        private readonly ApplicationDbContext _context;

        public EntradaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Entrada>> GetAllAsync() =>
            await _context.Entradas.ToListAsync();

        public async Task<Entrada?> GetByIdAsync(int id) =>
            await _context.Entradas.FindAsync(id);

        public async Task AddAsync(Entrada entrada)
        {
            _context.Entradas.Add(entrada);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Entrada entrada)
        {
            _context.Entradas.Update(entrada);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entrada = await GetByIdAsync(id);
            if (entrada != null)
            {
                _context.Entradas.Remove(entrada);
                await _context.SaveChangesAsync();
            }
        }
    }
}
