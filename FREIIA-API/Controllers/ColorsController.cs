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
    [Route("api/[controller]")]
    [ApiController]
    public class ColorsController : ControllerBase
    {
        private readonly int _defaultColorId = 8;
        private readonly FREIIAContext _context;

        public ColorsController(FREIIAContext context)
        {
            _context = context;
        }

        // GET: api/Colors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Color>>> GetColors()
        {
          if (_context.Colors == null)
          {
              return NotFound();
          }
            return await _context.Colors.ToListAsync();
        }

        // GET: api/Colors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Color>> GetColor(int id)
        {
          if (_context.Colors == null)
          {
              return NotFound();
          }
            var color = await _context.Colors.FindAsync(id);

            if (color == null)
            {
                return NotFound();
            }

            return color;
        }

        // PUT: api/Colors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutColor(int id, Color color)
        {
            if (id != color.Id)
            {
                return BadRequest();
            }

            _context.Entry(color).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ColorExists(id))
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

        // POST: api/Colors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<Color>> PostColor(Color color)
        //{
        //  if (_context.Colors == null)
        //  {
        //      return Problem("Entity set 'FREIIAContext.Colors'  is null.");
        //  }
        //    _context.Colors.Add(color);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetColor", new { id = color.Id }, color);
        //}

        private readonly List<Color> _colors = new List<Color>();
        private int _nextColorId = 1;

        // POST: api/colors
        [HttpPost]
        public async Task<ActionResult<Color>> PostColor(Color color)
        {
            // Assuming you validate the color object before adding it
            if (ModelState.IsValid)
            {
                // Find the corresponding chart by ChartId
                var chart = await _context.Charts.FindAsync(color.ChartId);
                if (chart == null)
                {
                    return NotFound("Chart not found.");
                }

                // Add the color to the data store
                _context.Colors.Add(color);

                // Save changes to the data store
                await _context.SaveChangesAsync();

                // Return a successful response with the newly created color
                return CreatedAtAction(nameof(GetColor), new { id = color.Id }, color);
            }

            // If the color object is invalid, return a bad request response
            return BadRequest(ModelState);
        }

        // DELETE: api/Colors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteColor(int id)
        {
            if (_context.Colors == null)
            {
                return NotFound();
            }
            var color = await _context.Colors.FindAsync(id);
            if (color == null)
            {
                return NotFound();
            }
            if (color != null)
            {
                //Defining the colorid in the ConnectionStyles Table and matching it the ColorId
                var connectionStyle = _context.ConnectionStyles
                    .FirstOrDefault(cs => cs.Color == color);
                if (connectionStyle != null)
                {
                    _context.ConnectionStyles.Remove(connectionStyle);
                }
                // We will change all Roles that have this colorID to default
                var rolesToUpdate = _context.Roles.Where(r => r.ColorId == id);
                foreach (var role in rolesToUpdate)
                {
                    role.ColorId = _defaultColorId;
                }

                // We will change all Groups that have this colorID to default
                var groupsToUpdate = _context.Groups.Where(g => g.ColorId == id);
                foreach (var group in groupsToUpdate)
                {
                    group.ColorId = _defaultColorId;
                }

                // We will change all Zones that have this colorID to default
                var zonesToUpdate = _context.Zones.Where(z => z.ColorId == id);
                foreach (var zone in zonesToUpdate)
                {
                    zone.ColorId = _defaultColorId;
                }
                // We will change all Expertise that have this colorID to default
                var expertiseToUpdate = _context.Expertises.Where(e => e.ColorId == id);
                foreach (var expertise in expertiseToUpdate)
                {
                    expertise.ColorId = _defaultColorId;
                }
            }

            _context.Colors.Remove(color);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ColorExists(int id)
        {
            return (_context.Colors?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
