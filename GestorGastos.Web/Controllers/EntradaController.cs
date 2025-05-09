using Microsoft.AspNetCore.Mvc;
using GestorGastos.Web.Models;
using GestorGastos.Web.Services;

namespace GestorGastos.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntradaController : ControllerBase
    {
        private readonly EntradaService _service;

        public EntradaController(EntradaService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() =>
            Ok(await _service.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var entrada = await _service.GetByIdAsync(id);
            return entrada == null ? NotFound() : Ok(entrada);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Entrada entrada)
        {
            await _service.AddAsync(entrada);
            return CreatedAtAction(nameof(Get), new { id = entrada.Id }, entrada);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Entrada entrada)
        {
            if (id != entrada.Id) return BadRequest();
            await _service.UpdateAsync(entrada);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
