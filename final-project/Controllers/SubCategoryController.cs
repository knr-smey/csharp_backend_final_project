using final_project.Data;
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

            return Ok(subCategories);
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

            return Ok(subCategory);
        }

        // POST: api/SubCategory
        [HttpPost]
        public async Task<IActionResult> Create(SubCategory subCategory)
        {
            var categoryExists = await _context.Categories
                .AnyAsync(c => c.Id == subCategory.CategoryId);

            if (!categoryExists)
                return BadRequest("Category does not exist.");

            subCategory.CreatedBy = 1; // example user id
            subCategory.CreatedAt = DateTime.Now;
            subCategory.UpdatedAt = DateTime.Now;

            _context.SubCategories.Add(subCategory);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = subCategory.Id }, subCategory);
        }

        // PUT: api/SubCategory/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, SubCategory updatedSubCategory)
        {
            if (id != updatedSubCategory.Id)
                return BadRequest();

            var subCategory = await _context.SubCategories.FindAsync(id);

            if (subCategory == null)
                return NotFound();

            var categoryExists = await _context.Categories
                .AnyAsync(c => c.Id == updatedSubCategory.CategoryId);

            if (!categoryExists)
                return BadRequest("Category does not exist.");

            subCategory.SubCategoryName = updatedSubCategory.SubCategoryName;
            subCategory.CategoryId = updatedSubCategory.CategoryId;
            subCategory.UpdatedAt = DateTime.Now;

            await _context.SaveChangesAsync();

            return Ok(subCategory);
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