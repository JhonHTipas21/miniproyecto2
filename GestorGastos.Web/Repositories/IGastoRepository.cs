using System.Collections.Generic;
using System.Threading.Tasks;
using GestorGastos.Web.Models;

namespace GestorGastos.Web.Repositories
{
    public interface IGastoRepository
    {
        Task<List<Gasto>> GetAllAsync();
        Task<Gasto?> GetByIdAsync(int id);
        Task AddAsync(Gasto gasto);
        Task UpdateAsync(Gasto gasto);
        Task DeleteAsync(int id);
    }
}
