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
    public class ConnectionsController : ControllerBase
    {
        private readonly FREIIAContext _context;

        public ConnectionsController(FREIIAContext context)
        {
            _context = context;
        }

        // GET: api/Connections
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Connection>>> GetConnections()
        {
          if (_context.Connections == null)
          {
              return NotFound();
          }
            return await _context.Connections.ToListAsync();
        }

        // GET: api/Connections/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Connection>> GetConnection(int id)
        {
          if (_context.Connections == null)
          {
              return NotFound();
          }
            var connection = await _context.Connections.FindAsync(id);

            if (connection == null)
            {
                return NotFound();
            }

            return connection;
        }

        // PUT: api/Connections/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConnection(int id, Connection connection)
        {
            if (id != connection.Id)
            {
                return BadRequest();
            }

            _context.Entry(connection).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConnectionExists(id))
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

        // POST: api/Connections
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Connection>> PostConnection(Connection connection)
        {
          if (_context.Connections == null)
          {
              return Problem("Entity set 'FREIIAContext.Connections'  is null.");
          }
            _context.Connections.Add(connection);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetConnection", new { id = connection.Id }, connection);
        }

        // DELETE: api/Connections/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConnection(int id)
        {
            if (_context.Connections == null)
            {
                return NotFound();
            }
            var connection = await _context.Connections.FindAsync(id);
            if (connection == null)
            {
                return NotFound();
            }

            _context.Connections.Remove(connection);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ConnectionExists(int id)
        {
            return (_context.Connections?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
