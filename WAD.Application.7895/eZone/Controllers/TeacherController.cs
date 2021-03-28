using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using eZone.DAL;
using eZone.DAL.DBO;
using eZone.DAL.Repositories;

namespace eZone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly IRepository<Teacher> _teacherRepo;

        public TeacherController(IRepository<Teacher> teacherRepo)
        {
            _teacherRepo = teacherRepo;
        }

        // GET: api/Teacher
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Teacher>>> GetTeachers()
        {
            return await _teacherRepo.GetAllAsync();
        }

        // GET: api/Teacher/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Teacher>> GetTeacher(int id)
        {
            var teacher = await _teacherRepo.GetByIdAsync(id);

            if (teacher == null)
            {
                return NotFound();
            }

            return teacher;
        }

        // PUT: api/Teacher/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTeacher(int id, Teacher teacher)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != teacher.Id)
            {
                return BadRequest();
            }

            try
            {
                await _teacherRepo.UpdateAsync(teacher);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_teacherRepo.Exists(id))
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

        // POST: api/Teacher
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Teacher>> PostTeacher(Teacher teacher)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            
            await _teacherRepo.CreateAsync(teacher);

            return CreatedAtAction("GetTeacher", new { id = teacher.Id }, teacher);
        }

        // DELETE: api/Teacher/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeacher(int id)
        {
            var teacher = await _teacherRepo.GetByIdAsync(id);
            if (teacher == null)
            {
                return NotFound();
            }

            await _teacherRepo.DeleteAsync(id);

            return NoContent();
        }        
    }
}
