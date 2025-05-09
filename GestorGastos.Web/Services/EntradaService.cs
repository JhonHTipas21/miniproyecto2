using System.Collections.Generic;
using System.Threading.Tasks;
using GestorGastos.Web.Models;
using GestorGastos.Web.Repositories;

namespace GestorGastos.Web.Services
{
    public class EntradaService
    {
        private readonly IEntradaRepository _repository;

        public EntradaService(IEntradaRepository repository)
        {
            _repository = repository;
        }

        public Task<List<Entrada>> GetAllAsync() => _repository.GetAllAsync();
        public Task<Entrada?> GetByIdAsync(int id) => _repository.GetByIdAsync(id);
        public Task AddAsync(Entrada entrada) => _repository.AddAsync(entrada);
        public Task UpdateAsync(Entrada entrada) => _repository.UpdateAsync(entrada);
        public Task DeleteAsync(int id) => _repository.DeleteAsync(id);
    }
}
