using ECommerce.Busniss_Logic.IunitofWork;
using ECommerce.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ECommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImageController : ControllerBase
    {
        private readonly IUnitofWork _unitOfWork;

        public ProductImageController(IUnitofWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProductImages()
        {
            try
            {
                var images = await _unitOfWork.ProductImageRepo.GetAllAsync();
                return Ok(images);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductImageById(int id)
        {
            try
            {
                var image = await _unitOfWork.ProductImageRepo.FindByIdAsync(id);
                if (image == null)
                    return NotFound();
                return Ok(image);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public IActionResult CreateProductImage([FromBody] ProductImage productImage)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                _unitOfWork.ProductImageRepo.AddOne(productImage);
                return CreatedAtAction(nameof(GetProductImageById), new { id = productImage.Id }, productImage);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProductImage(long id, [FromBody] ProductImage productImage)
        {
            try
            {
                if (!ModelState.IsValid || id != productImage.Id)
                    return BadRequest();

                var existingImage = _unitOfWork.ProductImageRepo.FindById((int)id);
                if (existingImage == null)
                    return NotFound();

                _unitOfWork.ProductImageRepo.UpdateOne(productImage);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProductImage(long id)
        {
            try
            {
                var image = _unitOfWork.ProductImageRepo.FindById((int)id);
                if (image == null)
                    return NotFound();

                _unitOfWork.ProductImageRepo.DeleteOne(image);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}