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
    public class ParticipantContactInfoesController : ControllerBase
    {
        private readonly FREIIAContext _context;

        public ParticipantContactInfoesController(FREIIAContext context)
        {
            _context = context;
        }

        // GET: api/ParticipantContactInfoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ParticipantContactInfo>>> GetParticipantContactInfos()
        {
          if (_context.ParticipantContactInfos == null)
          {
              return NotFound();
          }
            return await _context.ParticipantContactInfos.ToListAsync();
        }

        // GET: api/ParticipantContactInfoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ParticipantContactInfo>> GetParticipantContactInfo(int id)
        {
          if (_context.ParticipantContactInfos == null)
          {
              return NotFound();
          }
            var participantContactInfo = await _context.ParticipantContactInfos.FindAsync(id);

            if (participantContactInfo == null)
            {
                return NotFound();
            }

            return participantContactInfo;
        }

        // PUT: api/ParticipantContactInfoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutParticipantContactInfo(int id, ParticipantContactInfo participantContactInfo)
        {
            if (id != participantContactInfo.Id)
            {
                return BadRequest();
            }

            _context.Entry(participantContactInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParticipantContactInfoExists(id))
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

        // POST: api/ParticipantContactInfoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ParticipantContactInfo>> PostParticipantContactInfo(ParticipantContactInfo participantContactInfo)
        {
          if (_context.ParticipantContactInfos == null)
          {
              return Problem("Entity set 'FREIIAContext.ParticipantContactInfos'  is null.");
          }
            _context.ParticipantContactInfos.Add(participantContactInfo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetParticipantContactInfo", new { id = participantContactInfo.Id }, participantContactInfo);
        }

        // DELETE: api/ParticipantContactInfoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteParticipantContactInfo(int id)
        {
            if (_context.ParticipantContactInfos == null)
            {
                return NotFound();
            }
            var participantContactInfo = _context.ParticipantContactInfos.FirstOrDefault(c => c.Id == id);

            if(participantContactInfo != null)
            {
                var participant = await _context.Participants.Where(p => p.ContactInfo.Id == id).FirstAsync();

                participant.ContactInfo = null;
            }

            _context.ParticipantContactInfos.Remove(participantContactInfo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ParticipantContactInfoExists(int id)
        {
            return (_context.ParticipantContactInfos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
