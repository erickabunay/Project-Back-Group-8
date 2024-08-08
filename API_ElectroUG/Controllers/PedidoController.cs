using API_ElectroUG.Context;
using API_ElectroUG.Models;
using API_ElectroUG.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_ElectroUG.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoRepository _pedidoRepository;

        public PedidoController(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPedidos()
        {
            var pedidos = await _pedidoRepository.GetAllAsync();
            return Ok(pedidos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPedidoById(int id)
        {
            var pedido = await _pedidoRepository.GetByIdAsync(id);
            if (pedido == null)
            {
                return NotFound();
            }
            return Ok(pedido);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePedidoAsync([FromBody] Pedido pedido)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Datos del Pedido Invalidos");
            }

            await _pedidoRepository.CreateAsync(pedido);
            return Ok(pedido);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePedidoAsync(int id, [FromBody] Pedido pedido)
        {
            if (id != pedido.PedidoId)
            {
                return BadRequest("El Id " + id + " del pedido no existe.");
            }

            var updatedPedido = await _pedidoRepository.UpdateAsync(pedido);

            if (updatedPedido != null)
            {
                return Ok(updatedPedido);
            }
            else
            {
                return NotFound("El pedido con el Id " + id + " no existe.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePedidoAsync(int id)
        {
            var pedido = await _pedidoRepository.GetByIdAsync(id);
            if (pedido == null)
            {
                return NotFound("Pedido no encontrado");
            }
            await _pedidoRepository.DeleteByIdAsync(id);
            return Ok("Pedido eliminado correctamente");
        }
    }
}
