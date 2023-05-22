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
    // Här har det tidigare stått " [Route("api/[controller]")]"
    [Route("[controller]")]
    [ApiController]
    public class ChartsController : ControllerBase
    {
        private readonly FREIIAContext _context;

        public ChartsController(FREIIAContext context)
        {
            _context = context;
        }

        // GET: api/Charts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Chart>>> GetCharts()
        {
            if (_context.Charts == null)
            {
                return NotFound();
            }

            var results = await _context.Charts
                .Include(c => c.Zones)
                .ThenInclude(z => z.Color)
                .Include(c => c.Zones)
                .ThenInclude(z => z.Groups)
                .ThenInclude(g => g.Participants)
                .ThenInclude(p => p.Role)
                .Include(c => c.Zones)
                .ThenInclude(z => z.Participants)
                .ThenInclude(p => p.Role)
                .ThenInclude(r => r.Color)

                .Include(c => c.Groups)
                .ThenInclude(g => g.Color)
                .Include(c => c.Groups)
                .ThenInclude(g => g.Participants)
                .ThenInclude(p => p.Role)
                .ThenInclude(r => r.Color)

                .Include(c => c.Participants)
                //.ThenInclude(p => p.ExpertiseParticipants)
                //.ThenInclude(exp => exp.color)
                .ToListAsync();

            return results;
        }

        // GET: api/Charts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Chart>> GetChart(int id)
        {
            if (_context.Charts == null)
            {
                return NotFound();
            }

            var chart = await _context.Charts
                .Include(c => c.Zones)
                .ThenInclude(z => z.Color)
                .Include(c => c.Zones)
                .ThenInclude(z => z.Groups)
                .ThenInclude(g => g.Participants)
                .ThenInclude(p => p.Role)
                .Include(c => c.Zones)
                .ThenInclude(z => z.Participants)
                .ThenInclude(p => p.Role)
                .ThenInclude(r => r.Color)
                .Include(c => c.Groups)
                .ThenInclude(g => g.Color)
                .Include(c => c.Groups)
                .ThenInclude(g => g.Participants)
                .ThenInclude(p => p.Role)
                .ThenInclude(r => r.Color)
                .Include(c => c.Participants)
                .Where(c => c.Id == id)
                .FirstOrDefaultAsync();

            if (chart == null)
            {
                return NotFound();
            }

            return chart;
        }

        // GET: api/Charts/5/Groups
        [HttpGet("{id}/Groups")]
        public async Task<ActionResult<IEnumerable<Group>>> GetGroupsForChart(int id)
        {
            var chart = await _context.Charts
                .Include(c => c.Groups)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (chart == null)
            {
                return NotFound();
            }

            return chart.Groups;
        }



        // PUT: api/Charts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChart(int id, Chart chart)
        {
            if (id != chart.Id)
            {
                return BadRequest();
            }

            _context.Entry(chart).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChartExists(id))
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

        // POST: api/Charts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Chart>> PostChart(Chart chart)
        {
            if (_context.Charts == null)
            {
                return Problem("Entity set 'FREIIAContext.Charts'  is null.");
            }
            _context.Charts.Add(chart);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetChart", new { id = chart.Id }, chart);
        }

        // DELETE: api/Charts/5
        // Here we need to delete Zones, Groups, participants and include all code that ranges to the tables 
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChart(int id)
        {
            if (_context.Charts == null)
            {
                return NotFound();
            }
            var chart = await _context.Charts.FindAsync(id);
            if (chart == null)
            {
                return NotFound();
            }
 
            //HACK: Kennys rekommendation, vet ej om det fungerar men testa.

            //ParticipantsController participantController = new ParticipantsController(_context);

            //GroupsController groupsController = new GroupsController(_context);

            //ZonesController zoneController = new ZonesController(_context);

            //foreach (var participant in chart.Participants)
            //{
            //    await participantController.DeleteParticipant(participant.Id);
            //}

            //foreach (var group in chart.Groups)
            //{
            //    await groupsController.DeleteGroup(group.Id);
            //}

            //var targetChart = _context.Charts.Include(c => c.Zones).Include(c => c.Groups).Include(c => c.Participants).SingleOrDefault(c => c.Id == chartId);
            //if (targetChart != null)
            //{
            //    // Removes all zones
            //    if (targetChart.Zones != null && targetChart.Zones.Count > 0)
            //    {
            //        _context.Zones.RemoveRange(targetChart.Zones);
            //    }

            //    // Removes all groups
            //    if (targetChart.Groups != null && targetChart.Groups.Count > 0)
            //    {
            //        _context.Groups.RemoveRange(targetChart.Groups);
            //    }

            //    // Removes all participants and their contact info
            //    if (targetChart.Participants != null && targetChart.Participants.Count > 0)
            //    {
            //        foreach (var participant in targetChart.Participants)
            //        {
            //            var contactInfo = participant.ContactInfo;
            //            if (contactInfo != null)
            //            {
            //                _context.ParticipantContactInfos.Remove(contactInfo);
            //            }
            //        }
            //        _context.Participants.RemoveRange(targetChart.Participants);
            //    }
            //}
            _context.Charts.Remove(chart);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ChartExists(int id)
        {
            return (_context.Charts?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
