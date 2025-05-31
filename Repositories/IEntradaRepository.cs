using System.Collections.Generic;
using System.Threading.Tasks;
using GestorGastos.Web.Models;

namespace GestorGastos.Web.Repositories
{
    public interface IEntradaRepository
    {
        Task<List<Entrada>> GetAllAsync();
        Task<Entrada?> GetByIdAsync(int id);
        Task AddAsync(Entrada entrada);
        Task UpdateAsync(Entrada entrada);
        Task DeleteAsync(int id);
    }
}
