using ECommerce.Busniss_Logic.IunitofWork;
using ECommerce.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ECommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IUnitofWork _unitOfWork;

        public ProductController(IUnitofWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            try
            {
                var products = await _unitOfWork.ProductRepo.GetAllAsync();
                return Ok(products);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            try
            {
                var product = await _unitOfWork.ProductRepo.FindByIdAsync(id);
                if (product == null)
                    return NotFound();
                return Ok(product);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public IActionResult CreateProduct([FromBody] Product product)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                _unitOfWork.ProductRepo.AddOne(product);
                return CreatedAtAction(nameof(GetProductById), new { id = product.Id }, product);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduct(long id, [FromBody] Product product)
        {
            try
            {
                if (!ModelState.IsValid || id != product.Id)
                    return BadRequest();

                var existingProduct = _unitOfWork.ProductRepo.FindById((int)id);
                if (existingProduct == null)
                    return NotFound();

                _unitOfWork.ProductRepo.UpdateOne(product);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(long id)
        {
            try
            {
                var product = _unitOfWork.ProductRepo.FindById((int)id);
                if (product == null)
                    return NotFound();

                _unitOfWork.ProductRepo.DeleteOne(product);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}