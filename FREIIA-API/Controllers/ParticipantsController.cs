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
    public class ParticipantsController : ControllerBase
    {
        private readonly FREIIAContext _context;

        public ParticipantsController(FREIIAContext context)
        {
            _context = context;
        }

        // GET: api/Participants
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Participant>>> GetParticipants()
        {
            if (_context.Participants == null)
            {
                return NotFound();
            }
            return await _context.Participants
                .Include(p => p.Role)
                .ThenInclude(r => r.Color)
                .Include(p => p.ContactInfo)
                .Include(p => p.ExpertiseParticipants)
                .Include(c1=>c1.ConnectionsAsFirstParticipant)
                .Include(c2 => c2.ConnectionsAsSecondParticipant)
                .ToListAsync();
        }

        // GET: api/Participants/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Participant>> GetParticipant(int id)
        {
            if (_context.Participants == null)
            {
                return NotFound();
            }
            var participant = await _context.Participants.FindAsync(id);


            if (participant == null)
            {
                return NotFound();
            }

            return participant;
        }

        // GET: api/Participants/5
        [HttpGet("MainExpertise/{id}")]
        public async Task<ActionResult<ExpertiseParticipant>> GetParticipantsMainExpertise(int id)
        {
            if (_context.Participants == null)
            {
                return NotFound();
            }

            return _context.ExpertiseParticipant
                .Where(exp => exp.ParticipantId == id && exp.IsMainExpertise).First();
        }

        // PUT: api/Participants/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutParticipant(int id, Participant participant)
        {
            if (id != participant.Id)
            {
                return BadRequest();
            }

            _context.Entry(participant).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParticipantExists(id))
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

        // POST: api/Participants
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Participant>> PostParticipant(Participant participant)
        {
            if (_context.Participants == null)
            {
                return Problem("Entity set 'FREIIAContext.Participants'  is null.");
            }
            _context.Participants.Add(participant);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetParticipant", new { id = participant.Id }, participant);
        }

        // DELETE: api/Participants/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteParticipant(int id)
        {
            if (_context.Participants == null)
            {
                return NotFound();
            }
            //Gets participant info and also info från ParticipantContactInfo
            var participant = _context.Participants
                .Include(p => p.ContactInfo)
                .Include(c1=>c1.ConnectionsAsFirstParticipant)
                .Include(c2=>c2.ConnectionsAsSecondParticipant)
                .SingleOrDefault(p => p.Id == id);
            if (participant != null)
            {
                // puts contactinfo for participant in a separate variable
                var contactInfo = participant.ContactInfo;
                if (contactInfo != null)
                {
                    // removes the connected row in ParticipantContactinfo
                    _context.ParticipantContactInfos.Remove(contactInfo);
                }

                // finds expertises connected to the specific participant
                var deleteExpertiseParticipantRow = _context.ExpertiseParticipant.Where(ep => ep.ParticipantId == id);
                // deletes the connection of the expertise for a participant not the expertise itself
                if (deleteExpertiseParticipantRow != null)
                {
                    _context.ExpertiseParticipant.RemoveRange(deleteExpertiseParticipantRow);
                }
                // if a participant1 is in connectionsTable, change it to null;
                foreach (var connectionAsFirstParticipant in participant.ConnectionsAsFirstParticipant)
                {
                    connectionAsFirstParticipant.FirstParticipantId = null;
                    // if there is only FirstParticipantID that is NOT null, and all other FK is NULL, delete row
                    if (Connection.CountForeignKeys(connectionAsFirstParticipant) == 1)
                    {
                        _context.Connections.Remove(connectionAsFirstParticipant);
                    }
                }
                // if a participant2 is in connectionsTable, change it to null;
                foreach (var connectionAsSecondParticipant in participant.ConnectionsAsSecondParticipant)
                {
                    connectionAsSecondParticipant.SecondParticipantId = null;
                    // if there is only FirstParticipantID that is NOT null, and all other FK is NULL, delete row
                    if (Connection.CountForeignKeys(connectionAsSecondParticipant) == 1)
                    {
                        _context.Connections.Remove(connectionAsSecondParticipant);
                    }
                }

            }

            _context.Participants.Remove(participant);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ParticipantExists(int id)
        {
            return (_context.Participants?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
