using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AgrarIS.Data;
using AgrarIS.Models;

namespace AgrarIS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SluzbeniksController : ControllerBase
    {
        private readonly AgrarISContext _context;

        public SluzbeniksController(AgrarISContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sluzbenik>>> GetSluzbenik()
        {
          if (_context.Sluzbenik == null)
          {
              return NotFound();
          }
            return await _context.Sluzbenik.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Sluzbenik>> GetSluzbenik(int id)
        {
          if (_context.Sluzbenik == null)
          {
              return NotFound();
          }
            var sluzbenik = await _context.Sluzbenik.FindAsync(id);

            if (sluzbenik == null)
            {
                return NotFound();
            }

            return sluzbenik;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutSluzbenik(int id, Sluzbenik sluzbenik)
        {
            if (id != sluzbenik.Id)
            {
                return BadRequest();
            }

            _context.Entry(sluzbenik).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SluzbenikExists(id))
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

        [HttpPost]
        public async Task<ActionResult<Sluzbenik>> PostSluzbenik(Sluzbenik sluzbenik)
        {
          if (_context.Sluzbenik == null)
          {
              return Problem("Entity set 'AgrarISContext.Sluzbenik'  is null.");
          }
            _context.Sluzbenik.Add(sluzbenik);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSluzbenik", new { id = sluzbenik.Id }, sluzbenik);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSluzbenik(int id)
        {
            if (_context.Sluzbenik == null)
            {
                return NotFound();
            }
            var sluzbenik = await _context.Sluzbenik.FindAsync(id);
            if (sluzbenik == null)
            {
                return NotFound();
            }

            _context.Sluzbenik.Remove(sluzbenik);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SluzbenikExists(int id)
        {
            return (_context.Sluzbenik?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
