﻿using System;
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
            return await _context.Charts.ToListAsync();
        }

        // GET: api/Charts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Chart>> GetChart(int id)
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

            return chart;
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