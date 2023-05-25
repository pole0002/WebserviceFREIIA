using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FREIIA_API.Data;
using FREIIA_API.Models;
using FREIIA_API.Utility;

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
            if (string.IsNullOrEmpty(participant.FirstName))
            {
                return BadRequest("First name is required.");
            }
            if (string.IsNullOrEmpty(participant.LastName))
            {
                return BadRequest("Last name is required.");
            }

            Requests requests = new Requests(_context); //allows the methods found in Requests.cs class to be accessed from this class.
            // Check if the chart exists
            Chart chart = requests.GetChartById(participant.ChartId);
            if (chart == null)
            {
                return NotFound(); // Or return any suitable response indicating chart not found
            }

            // Check if GroupId is provided and validate the group belongs to the same chart
            if (participant.GroupId.HasValue)
            {
                Group group = chart.Groups.FirstOrDefault(g => g.Id == participant.GroupId.Value);
                if (group == null)
                {
                    return BadRequest("Invalid GroupId."); // Return appropriate response if group is invalid
                }
            }

            // Check if ZoneId is provided and validate the zone belongs to the same chart
            if (participant.ZoneId.HasValue)
            {
                Zone zone = chart.Zones.FirstOrDefault(z => z.Id == participant.ZoneId.Value);
                if (zone == null)
                {
                    return BadRequest("Invalid ZoneId."); // Return appropriate response if zone is invalid
                }
            }

            // Add the participant to the chart
            chart.Participants.Add(participant);

            // Save changes to the chart
            await requests.SaveChartAsync(chart);

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
            if(participant == null)
            {
                return NotFound();
            }
            else if (participant != null)
            {
                // puts contactinfo for participant in a separate variable
                var contactInfo = participant.ContactInfo;
                if (contactInfo != null)
                {
                    // removes the connected row in ParticipantContactinfo
                    _context.ParticipantContactInfos.Remove(contactInfo);
                }

                // finds participant connected to the specific expertises
                var deleteExpertiseParticipantRow = _context.ExpertiseParticipant.Where(ep => ep.ParticipantId == id);
                // deletes the row in Expertiseparticipant table
                if (deleteExpertiseParticipantRow != null)
                {
                    _context.ExpertiseParticipant.RemoveRange(deleteExpertiseParticipantRow);
                }
                // if a participant1 is in connectionsTable, change it to null;
                foreach (var connectionAsFirstParticipant in participant.ConnectionsAsFirstParticipant)
                {
                    connectionAsFirstParticipant.FirstParticipantId = null;
                    // if there is only FirstParticipantID that is NOT null, and all other FK is NULL, delete row
                    if (connectionAsFirstParticipant.GetCountForeignKeys() == 1)
                    {
                        _context.Connections.Remove(connectionAsFirstParticipant);
                    }
                }
                // if a participant2 is in connectionsTable, change it to null;
                foreach (var connectionAsSecondParticipant in participant.ConnectionsAsSecondParticipant)
                {
                    connectionAsSecondParticipant.SecondParticipantId = null;
                    // if there is only FirstParticipantID that is NOT null, and all other FK is NULL, delete row
                    if (connectionAsSecondParticipant.GetCountForeignKeys() == 1)
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
