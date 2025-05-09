using System.Collections.Generic;
using System.Threading.Tasks;
using GestorGastos.Web.Models;
using GestorGastos.Web.Repositories;

namespace GestorGastos.Web.Services
{
    public class CategoriaService
    {
        private readonly ICategoriaRepository _repository;

        public CategoriaService(ICategoriaRepository repository)
        {
            _repository = repository;
        }

        public Task<List<Categoria>> GetAllAsync() => _repository.GetAllAsync();
        public Task<Categoria?> GetByIdAsync(int id) => _repository.GetByIdAsync(id);
        public Task AddAsync(Categoria categoria) => _repository.AddAsync(categoria);
        public Task UpdateAsync(Categoria categoria) => _repository.UpdateAsync(categoria);
        public Task DeleteAsync(int id) => _repository.DeleteAsync(id);
    }
}
