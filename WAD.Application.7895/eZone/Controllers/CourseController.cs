using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using eZone.DAL.DBO;
using eZone.DAL.Repositories;
using eZone.BLL.DTO;
using System.ComponentModel.DataAnnotations;
using eZone.BLL;

namespace eZone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly IRepository<Course> _courseRepo;

        public CourseController(IRepository<Course> coureRepo)
        {
            _courseRepo = coureRepo;
        }

        // GET: api/Course
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Course>>> GetCourses()
        {
            var courses = await _courseRepo.GetAllAsync();
            return Ok(courses.Select(c =>new CourseDTO { 
            Id = c.Id,
            CourseLevel = c.CourseLevel.GetAttribute<DisplayAttribute>().Name,
            CourseName = c.CourseName,
            CourseDuration = c.CourseDuration,
            Fee = c.Fee
            }));
        }

        // GET: api/Course/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Course>> GetCourse(int id)
        {
            var course = await _courseRepo.GetByIdAsync(id);

            if (course == null)
            {
                return NotFound();
            }

            return course;
        }

        // PUT: api/Course/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCourse(int id, Course course)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != course.Id)
            {
                return BadRequest();
            }
                        
            try
            {              
                await _courseRepo.UpdateAsync(course);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_courseRepo.Exists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Course
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Course>> PostCourse(Course course)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _courseRepo.CreateAsync(course);          

            return CreatedAtAction("GetCourse", new { id = course.Id }, course);
        }

        // DELETE: api/Course/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            var course = await _courseRepo.GetByIdAsync(id);
            if (course == null)
            {
                return NotFound();
            }

            await _courseRepo.DeleteAsync(id);

            return NoContent();
        }     
        
       /* [HttpGet]
        public IEnumerable<EnumValues> GetEnums()
        {
            return EnumExtensions.GetObjectList<CourseLevel>();
        }*/
    }
}
