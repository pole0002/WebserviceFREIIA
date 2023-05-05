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
    public class ConnectionStylesController : ControllerBase
    {
        private readonly FREIIAContext _context;

        public ConnectionStylesController(FREIIAContext context)
        {
            _context = context;
        }

        // GET: api/ConnectionStyles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ConnectionStyle>>> GetConnectionStyles()
        {
          if (_context.ConnectionStyles == null)
          {
              return NotFound();
          }
            return await _context.ConnectionStyles.ToListAsync();
        }

        // GET: api/ConnectionStyles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ConnectionStyle>> GetConnectionStyle(int id)
        {
          if (_context.ConnectionStyles == null)
          {
              return NotFound();
          }
            var connectionStyle = await _context.ConnectionStyles.FindAsync(id);

            if (connectionStyle == null)
            {
                return NotFound();
            }

            return connectionStyle;
        }

        // PUT: api/ConnectionStyles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConnectionStyle(int id, ConnectionStyle connectionStyle)
        {
            if (id != connectionStyle.Id)
            {
                return BadRequest();
            }

            _context.Entry(connectionStyle).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConnectionStyleExists(id))
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

        // POST: api/ConnectionStyles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ConnectionStyle>> PostConnectionStyle(ConnectionStyle connectionStyle)
        {
          if (_context.ConnectionStyles == null)
          {
              return Problem("Entity set 'FREIIAContext.ConnectionStyles'  is null.");
          }
            _context.ConnectionStyles.Add(connectionStyle);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetConnectionStyle", new { id = connectionStyle.Id }, connectionStyle);
        }

        // DELETE: api/ConnectionStyles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConnectionStyle(int id)
        {
            if (_context.ConnectionStyles == null)
            {
                return NotFound();
            }
            var connectionStyle = await _context.ConnectionStyles.FindAsync(id);
            if (connectionStyle == null)
            {
                return NotFound();
            }

            _context.ConnectionStyles.Remove(connectionStyle);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ConnectionStyleExists(int id)
        {
            return (_context.ConnectionStyles?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
