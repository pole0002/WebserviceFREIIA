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
    public class ZonesController : ControllerBase
    {
        private readonly FREIIAContext _context;

        public ZonesController(FREIIAContext context)
        {
            _context = context;
        }

        // GET: api/Zones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Zone>>> GetZones()
        {
            if (_context.Zones == null)
            {
                return NotFound();
            }
            return await _context.Zones
                .Include(z => z.Color)
                .Include(z => z.Groups)
                .ThenInclude(g => g.Participants)
                .ThenInclude(p => p.Role)
                .Include(z => z.Participants)
                .ThenInclude(p => p.Role)
                .ToListAsync();
        }

        // GET: api/Zones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Zone>> GetZone(int id)
        {
            if (_context.Zones == null)
            {
                return NotFound();
            }
            var zone = await _context.Zones.FindAsync(id);

            if (zone == null)
            {
                return NotFound();
            }

            return zone;
        }

        // PUT: api/Zones/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutZone(int id, Zone zone)
        {
            if (id != zone.Id)
            {
                return BadRequest();
            }

            _context.Entry(zone).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ZoneExists(id))
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

        // POST: api/Zones
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Zone>> PostZone(Zone zone)
        {
            if (_context.Zones == null)
            {
                return Problem("Entity set 'FREIIAContext.Zones'  is null.");
            }
            _context.Zones.Add(zone);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetZone", new { id = zone.Id }, zone);
        }

        // DELETE: api/Zones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteZone(int id)
        {
            if (_context.Zones == null)
            {
                return NotFound();
            }
            // including Group and Participants because there is a zoneId that are depending on the zone-table
            var zone = _context.Zones
             .Include(g=>g.Groups)
            .Include(p=>p.Participants)
            .Include(c1=>c1.ConnectionsAsFirstZone)
            .Include(c2 => c2.ConnectionsAsSecondZone)
            .SingleOrDefault(g=> g.Id == id);
            if (zone == null)
            {
                return NotFound();
            }
            // changing ZoneId in groups to null
            foreach (var group in zone.Groups)
            {
                group.ZoneId = null;
                // if we delete a zone in witch there are groups, change isToplevel of groups to True
                group.IsTopLevel = true;
            }
            // changing zoneId in Participants to null
            foreach (var participants in zone.Participants)
            {
                participants.ZoneId = null;
                if(participants.GroupId == null)
                {
                    participants.IsTopLevel = true;
                }
            }
           
            foreach (var connectionsAsFirstZone in zone.ConnectionsAsFirstZone)
            {
                // changing zoneId to null in CONNECTIONS-table if a zone is deleted 
                connectionsAsFirstZone.FirstZoneId = null;
                // if there is only FirstZoneID that is NOT null, and all other FK is NULL, delete row
                if (CountForeignKeys(connectionsAsFirstZone) == 1)
                {
                    _context.Connections.Remove(connectionsAsFirstZone);
                }
               
            }
            // changing zoneId to null in CONNECTIONS-table if a zone is deleted 
            foreach (var connectionsAsSecondZone in zone.ConnectionsAsSecondZone)
            {
                connectionsAsSecondZone.SecondZoneId = null;
                // if there is only SecondZoneId that is NOT null, and all other FK is NULL, delete row
                if (CountForeignKeys(connectionsAsSecondZone) == 1)
                {
                    _context.Connections.Remove(connectionsAsSecondZone);
                }

            }
            
            _context.Zones.Remove(zone);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // Private method for counting how many FK are left in connectionstable
        private int CountForeignKeys(Connection connection)
        {
            int count = 0;

            if (connection.FirstZoneId != null)
            {
                count++;
            }
            if (connection.SecondZoneId != null)
            {
                count++;
            }
            if (connection.FirstGroupId != null)
            {
                count++;
            }
            if (connection.SecondGroupId != null)
            {
                count++;
            }
            if (connection.FirstParticipantId != null)
            {
                count++;
            }
            if (connection.SecondParticipantId != null)
            {
                count++;
            }

            return count;
        }

        private bool ZoneExists(int id)
        {
            return (_context.Zones?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
