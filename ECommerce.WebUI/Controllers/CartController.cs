using ECommerce.Busniss_Logic.IunitofWork;
using ECommerce.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ECommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly IUnitofWork _unitOfWork;

        public CartController(IUnitofWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetCartByUserId(string userId)
        {
            try
            {
                var cart = await _unitOfWork.CartRepo.GetAllAsync(c => c.UserId == userId);
                if (cart == null || !cart.Any())
                    return NotFound();
                return Ok(cart.First());
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public IActionResult CreateCart([FromBody] Cart cart)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                cart.CreatedAt = DateTime.UtcNow;
                cart.UpdatedAt = DateTime.UtcNow;
                _unitOfWork.CartRepo.AddOne(cart);
                return CreatedAtAction(nameof(GetCartByUserId), new { userId = cart.UserId }, cart);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCart(long id, [FromBody] Cart cart)
        {
            try
            {
                if (!ModelState.IsValid || id != cart.Id)
                    return BadRequest();

                var existingCart = _unitOfWork.CartRepo.FindById((int)id);
                if (existingCart == null)
                    return NotFound();

                cart.UpdatedAt = DateTime.UtcNow;
                _unitOfWork.CartRepo.UpdateOne(cart);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCart(long id)
        {
            try
            {
                var cart = _unitOfWork.CartRepo.FindById((int)id);
                if (cart == null)
                    return NotFound();

                _unitOfWork.CartRepo.DeleteOne(cart);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}