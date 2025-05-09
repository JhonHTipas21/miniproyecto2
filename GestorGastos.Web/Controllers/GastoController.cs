using Microsoft.AspNetCore.Mvc;
using GestorGastos.Web.Models;
using GestorGastos.Web.Services;

namespace GestorGastos.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GastoController : ControllerBase
    {
        private readonly GastoService _service;

        public GastoController(GastoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() =>
            Ok(await _service.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var gasto = await _service.GetByIdAsync(id);
            return gasto == null ? NotFound() : Ok(gasto);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Gasto gasto)
        {
            await _service.AddAsync(gasto);
            return CreatedAtAction(nameof(Get), new { id = gasto.Id }, gasto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Gasto gasto)
        {
            if (id != gasto.Id) return BadRequest();
            await _service.UpdateAsync(gasto);
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
