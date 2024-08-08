
using API_ElectroUG.Context;
using API_ElectroUG.Models;
using API_ElectroUG.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace API_ElectroUG.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarritoController : ControllerBase
    {
        private readonly ICarritoRepository _carritoRepository;

        public CarritoController(ICarritoRepository carritoRepository)
        {
            _carritoRepository = carritoRepository;
        }

       
        [HttpGet]
        public async Task<IActionResult> GetAllCarritos()
        {
            var carritos = await _carritoRepository.GetAllAsync();
            return Ok(carritos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCarritoById(int id)
        {
            var carrito = await _carritoRepository.GetByIdAsync(id);
            if (carrito == null)
            {
                return NotFound();
            }
            return Ok(carrito);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCarritoAsync([FromBody] Carrito carrito)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Datos del Carrito Invalidos");
            }

            await _carritoRepository.CreateAsync(carrito);
            return Ok(carrito);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCarritoAsync(int id, [FromBody] Carrito carrito)
        {
            if (id != carrito.CarritoId)
            {
                return BadRequest("El Id " + id + " del carrito no existe.");
            }

            var updatedCarrito = await _carritoRepository.UpdateAsync(carrito);

            if (updatedCarrito != null)
            {
                return Ok(updatedCarrito);
            }
            else
            {
                return NotFound("El carrito con el Id " + id + " no existe.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarritoAsync(int id)
        {
            var carrito = await _carritoRepository.GetByIdAsync(id);
            if (carrito == null)
            {
                return NotFound("Carrito no encontrado");
            }
            await _carritoRepository.DeleteByIdAsync(id);
            return Ok("Carrito eliminado correctamente");
        }
    }
}
