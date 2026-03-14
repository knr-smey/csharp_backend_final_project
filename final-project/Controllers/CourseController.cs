using final_project.Data;
using final_project.DTOs.Course;
using final_project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace final_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CourseController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Course
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var courses = await _context.Courses
                .AsNoTracking()
                .Select(course => new CourseResponseDto
                {
                    Id = course.Id,
                    CourseName = course.CourseName,
                    Des = course.Des,
                    Price = course.Price,
                    Thumbnail = course.Thumbnail,
                    CreatedBy = course.CreatedBy,
                    CreatedAt = course.CreatedAt,
                    UpdatedAt = course.UpdatedAt
                })
                .ToListAsync();

            return Ok(courses);
        }

        // GET: api/Course/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var course = await _context.Courses
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);

            if (course == null)
            {
                return NotFound();
            }

            return Ok(MapCourse(course));
        }

        // POST: api/Course
        [HttpPost]
        public async Task<IActionResult> Create(CourseCreateDto courseDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var course = new Course
            {
                CourseName = courseDto.CourseName,
                Des = courseDto.Des,
                Price = courseDto.Price,
                Thumbnail = courseDto.Thumbnail,
                CreatedBy = 1,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            _context.Courses.Add(course);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = course.Id }, MapCourse(course));
        }

        // PUT: api/Course/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CourseUpdateDto courseDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var course = await _context.Courses.FindAsync(id);

            if (course == null)
            {
                return NotFound();
            }

            course.CourseName = courseDto.CourseName;
            course.Des = courseDto.Des;
            course.Price = courseDto.Price;
            course.Thumbnail = courseDto.Thumbnail;
            course.UpdatedAt = DateTime.Now;

            await _context.SaveChangesAsync();

            return Ok(MapCourse(course));
        }

        // DELETE: api/Course/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var course = await _context.Courses.FindAsync(id);

            if (course == null)
            {
                return NotFound();
            }

            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private static CourseResponseDto MapCourse(Course course)
        {
            return new CourseResponseDto
            {
                Id = course.Id,
                CourseName = course.CourseName,
                Des = course.Des,
                Price = course.Price,
                Thumbnail = course.Thumbnail,
                CreatedBy = course.CreatedBy,
                CreatedAt = course.CreatedAt,
                UpdatedAt = course.UpdatedAt
            };
        }
    }
}
