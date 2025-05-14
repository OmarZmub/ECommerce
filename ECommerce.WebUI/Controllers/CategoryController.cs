using ECommerce.Busniss_Logic.IunitofWork;
using ECommerce.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ECommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IUnitofWork _unitOfWork;

        public CategoryController(IUnitofWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            try
            {
                var categories = await _unitOfWork.CategoryRepo.GetAllAsync();
                return Ok(categories);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            try
            {
                var category = await _unitOfWork.CategoryRepo.FindByIdAsync(id);
                if (category == null)
                    return NotFound();
                return Ok(category);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public IActionResult CreateCategory([FromBody] Category category)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                category.CreatedAt = DateTime.UtcNow;
                category.UpdatedAt = DateTime.UtcNow;
                category.Status = true;
                _unitOfWork.CategoryRepo.AddOne(category);
                return CreatedAtAction(nameof(GetCategoryById), new { id = category.Id }, category);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCategory(long id, [FromBody] Category category)
        {
            try
            {
                if (!ModelState.IsValid || id != category.Id)
                    return BadRequest();

                var existingCategory = _unitOfWork.CategoryRepo.FindById((int)id);
                if (existingCategory == null)
                    return NotFound();

                category.UpdatedAt = DateTime.UtcNow;
                _unitOfWork.CategoryRepo.UpdateOne(category);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(long id)
        {
            try
            {
                var category = _unitOfWork.CategoryRepo.FindById((int)id);
                if (category == null)
                    return NotFound();

                _unitOfWork.CategoryRepo.DeleteOne(category);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}