using API_ElectroUG.Models;
using API_ElectroUG.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_ElectroUG.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarritoController : ControllerBase
    {
        private readonly IRepositorioCarrito _repositorioCarrito;

        public CarritoController(IRepositorioCarrito repositorioCarrito)
        {
            _repositorioCarrito = repositorioCarrito;
        }
        // GET: api/<CarritoController>
        [HttpGet]
        public async Task<IActionResult> GetCarritos()
        {
            var carrrito = await _repositorioCarrito.ObtenerTodos();
            return Ok(carrrito);
        }
        [HttpPost]
        public async Task<IActionResult> CrearCarrito([FromBody] Carrito carrito)
        {
            await _repositorioCarrito.Crear(carrito);
            return Ok(carrito);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPedidos()
        {
            var pedido = await _repositorioCarrito.GetEnviadosAsync();
            return Ok(pedido);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var carrito = _repositorioCarrito.ObtenerPorId(id);
                if (carrito == null)
                {
                    return NotFound("El carrito no fue encontrado.");
                }

                await _repositorioCarrito.Eliminar(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

    }
}
