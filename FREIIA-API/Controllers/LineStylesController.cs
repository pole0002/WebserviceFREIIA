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
    public class LineStylesController : ControllerBase
    {
        private readonly FREIIAContext _context;

        public LineStylesController(FREIIAContext context)
        {
            _context = context;
        }

        // GET: api/LineStyles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LineStyle>>> GetLineStyles()
        {
          if (_context.LineStyles == null)
          {
              return NotFound();
          }
            return await _context.LineStyles.ToListAsync();
        }

        // GET: api/LineStyles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LineStyle>> GetLineStyle(int id)
        {
          if (_context.LineStyles == null)
          {
              return NotFound();
          }
            var lineStyle = await _context.LineStyles.FindAsync(id);

            if (lineStyle == null)
            {
                return NotFound();
            }

            return lineStyle;
        }

        // PUT: api/LineStyles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLineStyle(int id, LineStyle lineStyle)
        {
            if (id != lineStyle.Id)
            {
                return BadRequest();
            }

            _context.Entry(lineStyle).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LineStyleExists(id))
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

        // POST: api/LineStyles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LineStyle>> PostLineStyle(LineStyle lineStyle)
        {
          if (_context.LineStyles == null)
          {
              return Problem("Entity set 'FREIIAContext.LineStyles'  is null.");
          }
            _context.LineStyles.Add(lineStyle);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLineStyle", new { id = lineStyle.Id }, lineStyle);
        }

        // DELETE: api/LineStyles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLineStyle(int id)
        {
            if (_context.LineStyles == null)
            {
                return NotFound();
            }
            var lineStyle = await _context.LineStyles.FindAsync(id);
            if (lineStyle == null)
            {
                return NotFound();
            }

            _context.LineStyles.Remove(lineStyle);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LineStyleExists(int id)
        {
            return (_context.LineStyles?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
