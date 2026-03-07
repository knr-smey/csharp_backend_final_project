using final_project.Data;
using final_project.DTOs.SubCategory;
using final_project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace final_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubCategoryController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SubCategoryController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/SubCategory
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var subCategories = await _context.SubCategories
                .Include(s => s.Category)
                .Include(s => s.CreatedByUser)
                .ToListAsync();

            var response = subCategories.Select(s => new SubCategoryResponse
            {
                Id = s.Id,
                SubCategoryName = s.SubCategoryName,
                CategoryId = s.CategoryId,
                CreatedBy = s.CreatedBy,
                CreatedAt = s.CreatedAt,
                UpdatedAt = s.UpdatedAt
            }).ToList();

            return Ok(response);
        }

        // GET: api/SubCategory/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var subCategory = await _context.SubCategories
                .Include(s => s.Category)
                .Include(s => s.CreatedByUser)
                .FirstOrDefaultAsync(s => s.Id == id);

            if (subCategory == null)
                return NotFound();

            var response = new SubCategoryResponse
            {
                Id = subCategory.Id,
                SubCategoryName = subCategory.SubCategoryName,
                CategoryId = subCategory.CategoryId,
                CreatedBy = subCategory.CreatedBy,
                CreatedAt = subCategory.CreatedAt,
                UpdatedAt = subCategory.UpdatedAt
            };

            return Ok(response);
        }

        // POST: api/SubCategory
        [HttpPost]
        public async Task<IActionResult> Create(SubCategoryCreateRequest request)
        {
            var categoryExists = await _context.Categories
                .AnyAsync(c => c.Id == request.CategoryId);

            if (!categoryExists)
                return BadRequest("Category does not exist.");

            var subCategory = new SubCategory
            {
                SubCategoryName = request.SubCategoryName,
                CategoryId = request.CategoryId,
                CreatedBy = 1, // temporary, replace with JWT user id later
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            _context.SubCategories.Add(subCategory);
            await _context.SaveChangesAsync();

            var response = new SubCategoryResponse
            {
                Id = subCategory.Id,
                SubCategoryName = subCategory.SubCategoryName,
                CategoryId = subCategory.CategoryId,
                CreatedBy = subCategory.CreatedBy,
                CreatedAt = subCategory.CreatedAt,
                UpdatedAt = subCategory.UpdatedAt
            };

            return CreatedAtAction(nameof(GetById), new { id = subCategory.Id }, response);
        }

        // PUT: api/SubCategory/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, SubCategoryUpdateRequest request)
        {
            var subCategory = await _context.SubCategories.FindAsync(id);

            if (subCategory == null)
                return NotFound();

            var categoryExists = await _context.Categories
                .AnyAsync(c => c.Id == request.CategoryId);

            if (!categoryExists)
                return BadRequest("Category does not exist.");

            subCategory.SubCategoryName = request.SubCategoryName;
            subCategory.CategoryId = request.CategoryId;
            subCategory.UpdatedAt = DateTime.Now;

            await _context.SaveChangesAsync();

            var response = new SubCategoryResponse
            {
                Id = subCategory.Id,
                SubCategoryName = subCategory.SubCategoryName,
                CategoryId = subCategory.CategoryId,
                CreatedBy = subCategory.CreatedBy,
                CreatedAt = subCategory.CreatedAt,
                UpdatedAt = subCategory.UpdatedAt
            };

            return Ok(response);
        }

        // DELETE: api/SubCategory/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var subCategory = await _context.SubCategories.FindAsync(id);

            if (subCategory == null)
                return NotFound();

            _context.SubCategories.Remove(subCategory);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}