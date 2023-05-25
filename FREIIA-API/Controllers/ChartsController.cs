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

            var results = await _context.Charts.ToListAsync();

            //iterate over charts to remove duplicate participant and groups in results.
            foreach (var chart in results)
            {
                //Remove all participants that are not on top level in chart.
                chart.Participants.RemoveAll(p => p.IsTopLevel == false);

                //Remove all groups that are not on top level in chart.
                chart.Groups.RemoveAll(p => p.IsTopLevel == false);
            }

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
                .Where(c => c.Id == id).FirstAsync();

            if (chart == null)
            {
                return NotFound();
            }

            //Remove all participants that are not on top level in chart.
            chart.Participants.RemoveAll(p => p.IsTopLevel == false);

            //Remove all groups that are not on top level in chart.
            chart.Groups.RemoveAll(p => p.IsTopLevel == false);

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

            //ZonesController zonesController = new ZonesController(_context);
            //await zonesController.DeleteZone(id);

            //GroupsController groupsController = new GroupsController(_context);
            //await groupsController.DeleteGroup(id);

            

            var participants = _context.Participants.Where(p => p.ChartId == id);

            //LineStylesController lineStylesController = new LineStylesController(_context);
            //await lineStylesController.DeleteLineStyle(id);
            //ExpertisesController expertisesController = new ExpertisesController(_context);
            //await expertisesController.DeleteExpertise(id);
            //ColorsController colorsController = new ColorsController(_context);
            //await colorsController.DeleteColor(id);
            //RolesController rolesController = new RolesController(_context);
            //await rolesController.DeleteRole(id);


            //if (chart != null)
            //{
            //    if(chart.Zones != null)
            //    {
            //        foreach (var zone in chart.Zones)
            //        {
            //            _context.Zones.Remove(zone);
            //        }
            //    }
            //    if (chart.Groups != null)
            //    {
            //        foreach (var group in chart.Groups)
            //        {
            //           _context.Groups.Remove(group);
            //        }
            //    }
            //    if(chart.Participants != null)
            //    {
            //        foreach (var participant in chart.Participants)
            //        {
            //            _context.Participants.Remove(participant);
            //        }
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
