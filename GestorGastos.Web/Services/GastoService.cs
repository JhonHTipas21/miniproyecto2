using System.Collections.Generic;
using System.Threading.Tasks;
using GestorGastos.Web.Models;
using GestorGastos.Web.Repositories;

namespace GestorGastos.Web.Services
{
    public class GastoService
    {
        private readonly IGastoRepository _repository;

        public GastoService(IGastoRepository repository)
        {
            _repository = repository;
        }

        public Task<List<Gasto>> GetAllAsync() => _repository.GetAllAsync();
        public Task<Gasto?> GetByIdAsync(int id) => _repository.GetByIdAsync(id);
        public Task AddAsync(Gasto gasto) => _repository.AddAsync(gasto);
        public Task UpdateAsync(Gasto gasto) => _repository.UpdateAsync(gasto);
        public Task DeleteAsync(int id) => _repository.DeleteAsync(id);
    }
}
