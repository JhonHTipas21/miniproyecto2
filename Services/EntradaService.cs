using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestorGastos.Web.Data;
using GestorGastos.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace GestorGastos.Web.Services
{
    public class EntradaService
    {
        private readonly ApplicationDbContext _db;
        public EntradaService(ApplicationDbContext db) => _db = db;

        public Task<List<Entrada>> GetAllAsync()
            => _db.Entradas.OrderByDescending(e => e.Fecha).ToListAsync();

        public Task<Entrada?> GetByIdAsync(int id)
            => _db.Entradas.FindAsync(id).AsTask();

        public async Task AddAsync(Entrada e)
        {
            _db.Entradas.Add(e);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var e = await _db.Entradas.FindAsync(id);
            if (e != null)
            {
                _db.Entradas.Remove(e);
                await _db.SaveChangesAsync();
            }
        }
    }
}
