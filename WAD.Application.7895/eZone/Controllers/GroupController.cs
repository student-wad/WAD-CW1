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
    public class GroupController : ControllerBase
    {
        private readonly IRepository<Group> _groupRepo;

        public GroupController(IRepository<Group> groupRepo)
        {
            _groupRepo = groupRepo;
        }

        // GET: api/Group
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Group>>> GetGroups()
        {
            return await _groupRepo.GetAllAsync();
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
