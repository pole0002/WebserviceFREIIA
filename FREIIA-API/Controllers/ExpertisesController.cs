using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FREIIA_API.Data;
using FREIIA_API.Models;
using System.Security.Cryptography.X509Certificates;

namespace FREIIA_API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ExpertisesController : ControllerBase
    {
        private readonly FREIIAContext _context;

        public ExpertisesController(FREIIAContext context)
        {
            _context = context;
        }

        // GET: api/Expertises
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Expertise>>> GetExpertises()
        {
          if (_context.Expertises == null)
          {
              return NotFound();
          }
            return await _context.Expertises.ToListAsync();
        }

        // GET: api/Expertises/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Expertise>> GetExpertise(int id)
        {
          if (_context.Expertises == null)
          {
              return NotFound();
          }
            var expertise = await _context.Expertises.FindAsync(id);

            if (expertise == null)
            {
                return NotFound();
            }

            return expertise;
        }

        // PUT: api/Expertises/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExpertise(int id, Expertise expertise)
        {
            if (id != expertise.Id)
            {
                return BadRequest();
            }

            _context.Entry(expertise).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExpertiseExists(id))
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

        // POST: api/Expertises
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Expertise>> PostExpertise(Expertise expertise)
        {
          if (_context.Expertises == null)
          {
              return Problem("Entity set 'FREIIAContext.Expertises'  is null.");
          }
            _context.Expertises.Add(expertise);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetExpertise", new { id = expertise.Id }, expertise);
        }

        // DELETE: api/Expertises/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExpertise(int id)
        {
            if (_context.Expertises == null)
            {
                return NotFound();
            }
            Expertise expertise = _context.Expertises
                .Include(e => e.ExpertiseParticipants)
                .ThenInclude(p=>p.Participant)
                .FirstOrDefault(e => e.Id == id);
            if (expertise == null)
            {
                return NotFound();
            }

            if(expertise != null)
            {
                // defining that expertiseId is same as the expertise Id in the Expertise Table
                ExpertiseParticipant expertiseParticipantExpertiseId = expertise.ExpertiseParticipants
                    .FirstOrDefault(ep => ep.ExpertiseId == id);

                if(expertiseParticipantExpertiseId != null)
                {
                    // getting the participantID of the expertise
                    int participantId = expertiseParticipantExpertiseId.ParticipantId;

                    // find the next added expertise for participant
                    ExpertiseParticipant nextExpertiseParticipantExpertiseId = _context.ExpertiseParticipant
                        .Where(ep => ep.ParticipantId == participantId && ep.ExpertiseId != id)
                        .OrderBy(ep => ep.ExpertiseId)
                        .FirstOrDefault();

                    if(nextExpertiseParticipantExpertiseId != null)
                    {
                        // change isMainExpertise for the experticeparticipantrow of the next expertise in the list for thesame participant
                        nextExpertiseParticipantExpertiseId.IsMainExpertise = true;

                    }
                }
            }

            _context.Expertises.Remove(expertise);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        
        private bool ExpertiseExists(int id)
        {
            return (_context.Expertises?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
