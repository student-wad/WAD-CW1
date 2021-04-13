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
using eZone.DTO;
using eZone.BLL;
using System.ComponentModel.DataAnnotations;

namespace eZone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IRepository<Student> _studentRepo;

        public StudentController(IRepository<Student> studentRepo)
        {
            _studentRepo = studentRepo;
        }

        // GET: api/Student
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentDTO>>> GetStudents(int? groupId)
        {
            var students= await _studentRepo.GetAllAsync();
            if (groupId.HasValue)
            {
                students = students.Where(p => p.GroupId == groupId).ToList();
            }
            return Ok(students.Select(s=> new StudentDTO { 
            Id = s.Id,
            FirstName = s.FirstName,
            LastName = s.LastName,
            Phone = s.Phone,
            FirstLesson = s.FirstLesson,
            PaymentStatus = s.PaymentStatus.GetAttribute<DisplayAttribute>().Name,
            GroupId = s.Group.Id
            }));           
        }

        // GET: api/Student/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudent(int id)
        {
            var student = await _studentRepo.GetByIdAsync(id);

            if (student == null)
            {
                return NotFound();
            }

            return student;
        }

        // PUT: api/Student/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudent(int id, Student student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != student.Id)
            {
                return BadRequest();
            }

            
            try
            {
                await _studentRepo.UpdateAsync(student);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_studentRepo.Exists(id))
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

        // POST: api/Student
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Student>> PostStudent(Student student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _studentRepo.UpdateAsync(student);

            return CreatedAtAction("GetStudent", new { id = student.Id }, student);
        }

        // DELETE: api/Student/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var student = await _studentRepo.GetByIdAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            await _studentRepo.DeleteAsync(id);

            return NoContent();
        }
    }
}
