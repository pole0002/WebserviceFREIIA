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
    [Route("api/[controller]")]
    [ApiController]
    public class ExpertiseParticipantsController : ControllerBase
    {
        private readonly FREIIAContext _context;

        public ExpertiseParticipantsController(FREIIAContext context)
        {
            _context = context;
        }

        // GET: api/ExpertiseParticipants
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExpertiseParticipant>>> GetExpertiseParticipant()
        {
          if (_context.ExpertiseParticipant == null)
          {
              return NotFound();
          }
            return await _context.ExpertiseParticipant.ToListAsync();
        }

        // GET: api/ExpertiseParticipants/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ExpertiseParticipant>> GetExpertiseParticipant(int id)
        {
          if (_context.ExpertiseParticipant == null)
          {
              return NotFound();
          }
            var expertiseParticipant = await _context.ExpertiseParticipant.FindAsync(id);

            if (expertiseParticipant == null)
            {
                return NotFound();
            }

            return expertiseParticipant;
        }

        // PUT: api/ExpertiseParticipants/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExpertiseParticipant(int id, ExpertiseParticipant expertiseParticipant)
        {
            if (id != expertiseParticipant.ExpertiseId)
            {
                return BadRequest();
            }

            _context.Entry(expertiseParticipant).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExpertiseParticipantExists(id))
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

        // POST: api/ExpertiseParticipants
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ExpertiseParticipant>> PostExpertiseParticipant(ExpertiseParticipant expertiseParticipant)
        {
          if (_context.ExpertiseParticipant == null)
          {
              return Problem("Entity set 'FREIIAContext.ExpertiseParticipant'  is null.");
          }
            _context.ExpertiseParticipant.Add(expertiseParticipant);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ExpertiseParticipantExists(expertiseParticipant.ExpertiseId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetExpertiseParticipant", new { id = expertiseParticipant.ExpertiseId }, expertiseParticipant);
        }

        // DELETE: api/ExpertiseParticipants/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExpertiseParticipant(int id)
        {
            if (_context.ExpertiseParticipant == null)
            {
                return NotFound();
            }
            var expertiseParticipant = await _context.ExpertiseParticipant.FindAsync(id);
            if (expertiseParticipant == null)
            {
                return NotFound();
            }

            _context.ExpertiseParticipant.Remove(expertiseParticipant);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ExpertiseParticipantExists(int id)
        {
            return (_context.ExpertiseParticipant?.Any(e => e.ExpertiseId == id)).GetValueOrDefault();
        }
    }
}
