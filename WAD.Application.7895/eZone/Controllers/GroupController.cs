using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using eZone.DAL.DBO;
using eZone.DAL.Repositories;
using eZone.BLL.DTO;
using eZone.BLL;
using System.ComponentModel.DataAnnotations;

namespace eZone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private readonly IRepository<Group> _groupRepo;        

        public GroupController(IRepository<Group> groupRepo)
        {
            _groupRepo = groupRepo;
        }

        // GET: api/Group
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GroupDTO>>> GetGroups(int? teacherId)
        {
            var groups = await _groupRepo.GetAllAsync();
            if (teacherId.HasValue)
            {
                groups = groups.Where(p => p.TeacherId == teacherId).ToList();                
            }
            return Ok(groups.Select(g=>new GroupDTO()
             {
                 Id=g.Id,
                 GroupLevel= g.GroupLevel.GetAttribute<DisplayAttribute>().Name,
                 LessonDays = g.LessonDays.GetAttribute<DisplayAttribute>().Name,
                 GroupTime = g.GroupTime.GetAttribute<DisplayAttribute>().Name,
                 StartDate = g.StartDate,
                 GroupStatus = g.GroupStatus.GetAttribute<DisplayAttribute>().Name,
                 NumOfStudents =g.NumOfStudents,
                 CourseName = g.Course.CourseName,
                 TeacherFirstName = g.Teacher.FirstName                
             })); 
            
        }

        // GET: api/Group/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Group>> GetGroup(int id)
        {
            var group = await _groupRepo.GetByIdAsync(id);

            if (group == null)
            {
                return NotFound();
            }

            return group;
        }

        // PUT: api/Group/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGroup(int id, Group group)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != group.Id)
            {
                return BadRequest();
            }
            
            try
            {
                await _groupRepo.UpdateAsync(group);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_groupRepo.Exists(id))
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

        // POST: api/Group
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Group>> PostGroup(Group group)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
         
            await _groupRepo.CreateAsync(group);

            return CreatedAtAction("GetGroup", new { id = group.Id }, group);
        }

        // DELETE: api/Group/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGroup(int id)
        {
            var group = await _groupRepo.GetByIdAsync(id);
            if (group == null)
            {
                return NotFound();
            }

            await _groupRepo.DeleteAsync(id);

            return NoContent();
        }


    }
}
