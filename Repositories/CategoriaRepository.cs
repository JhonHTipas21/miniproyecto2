using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestorGastos.Web.Models;
using GestorGastos.Web.Data;
using Microsoft.EntityFrameworkCore;

namespace GestorGastos.Web.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoriaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Categoria>> GetAllAsync() =>
            await _context.Categorias.Include(c => c.Gastos).ToListAsync();

        public async Task<Categoria?> GetByIdAsync(int id) =>
            await _context.Categorias.Include(c => c.Gastos).FirstOrDefaultAsync(c => c.Id == id);

        public async Task AddAsync(Categoria categoria)
        {
            _context.Categorias.Add(categoria);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Categoria categoria)
        {
            _context.Categorias.Update(categoria);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var categoria = await GetByIdAsync(id);
            if (categoria != null)
            {
                _context.Categorias.Remove(categoria);
                await _context.SaveChangesAsync();
            }
        }
    }
}
