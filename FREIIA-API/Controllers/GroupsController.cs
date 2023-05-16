using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FREIIA_API.Data;
using FREIIA_API.Models;

namespace FREIIA_API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GroupsController : ControllerBase
    {
        private readonly FREIIAContext _context;

        public GroupsController(FREIIAContext context)
        {
            _context = context;
        }

        // GET: api/Groups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Group>>> GetGroups()
        {
          if (_context.Groups == null)
          {
              return NotFound();
          }
            return await _context.Groups.ToListAsync();
        }

        // GET: api/Groups/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Group>> GetGroup(int id)
        {
          if (_context.Groups == null)
          {
              return NotFound();
          }
            var @group = await _context.Groups.FindAsync(id);

            if (@group == null)
            {
                return NotFound();
            }

            return @group;
        }

        // PUT: api/Groups/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGroup(int id, Group @group)
        {
            if (id != @group.Id)
            {
                return BadRequest();
            }

            _context.Entry(@group).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GroupExists(id))
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

        // POST: api/Groups
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Group>> PostGroup(Group @group)
        {
          if (_context.Groups == null)
          {
              return Problem("Entity set 'FREIIAContext.Groups'  is null.");
          }
            _context.Groups.Add(@group);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGroup", new { id = @group.Id }, @group);
        }

        // DELETE: api/Groups/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGroup(int id)
        {
            if (_context.Groups == null)
            {
                return NotFound();
            }
            var group = _context.Groups
                .Include(p=>p.Participants)
                .Include(c1=>c1.ConnectionsAsFirstGroup)
                .Include(c2=>c2.ConnectionsAsSecondGroup)
                .SingleOrDefault(p => p.Id == id);
            if (group == null)
            {
                return NotFound();
            }
            // if we delete a group change groupId in participant to null
            foreach (var participant in group.Participants)
            {
                participant.GroupId = null;
                // If a group has zoneId, set zoneId from group to participanttable in zoneId-column
                if(group.ZoneId != null)
                {
                    participant.ZoneId = group.ZoneId;
                }
                 // if zoneId in participant is also null, change isTopLevel to true for participant
                else if(participant.ZoneId == null)
                {
                    participant.IsTopLevel = true;
                }   
            }
            // if a group is in connectionsTable, change it to null;
            foreach (var connectionsAsFirstGroup in group.ConnectionsAsFirstGroup)
            {
                connectionsAsFirstGroup.FirstGroupId = null;
            }
            // if a group is in connectionsTable, change it to null;
            foreach (var connectionsAsSecondGroup in group.ConnectionsAsSecondGroup)
            {
                connectionsAsSecondGroup.SecondGroupId = null;
            }


            _context.Groups.Remove(group);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GroupExists(int id)
        {
            return (_context.Groups?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
