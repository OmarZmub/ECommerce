using ECommerce.Busniss_Logic.IunitofWork;
using ECommerce.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ECommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IUnitofWork _unitOfWork;

        public OrderController(IUnitofWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            try
            {
                var orders = await _unitOfWork.OrderRepo.GetAllAsync();
                return Ok(orders);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderById(int id)
        {
            try
            {
                var order = await _unitOfWork.OrderRepo.FindByIdAsync(id);
                if (order == null)
                    return NotFound();
                return Ok(order);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public IActionResult CreateOrder([FromBody] Order order)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                order.OrderDate = DateTime.UtcNow;
                order.LastModifiedDate = DateTime.UtcNow;
                order.Active = true;

                _unitOfWork.OrderRepo.AddOne(order);
                return CreatedAtAction(nameof(GetOrderById), new { id = order.Id }, order);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateOrder(long id, [FromBody] Order order)
        {
            try
            {
                if (!ModelState.IsValid || id != order.Id)
                    return BadRequest();

                var existingOrder = _unitOfWork.OrderRepo.FindById((int)id);
                if (existingOrder == null)
                    return NotFound();

                order.LastModifiedDate = DateTime.UtcNow;
                _unitOfWork.OrderRepo.UpdateOne(order);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteOrder(long id)
        {
            try
            {
                var order = _unitOfWork.OrderRepo.FindById((int)id);
                if (order == null)
                    return NotFound();

                order.DeletedDate = DateTime.UtcNow;
                order.Active = false;
                _unitOfWork.OrderRepo.UpdateOne(order);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}