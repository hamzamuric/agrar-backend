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
    public class SubvencijasController : ControllerBase
    {
        private readonly AgrarISContext _context;

        public SubvencijasController(AgrarISContext context)
        {
            _context = context;
        }

        // GET: api/Subvencijas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Subvencija>>> GetSubvencija()
        {
          if (_context.Subvencija == null)
          {
              return NotFound();
          }
            return await _context.Subvencija.ToListAsync();
        }

        // GET: api/Subvencijas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Subvencija>> GetSubvencija(int id)
        {
          if (_context.Subvencija == null)
          {
              return NotFound();
          }
            var subvencija = await _context.Subvencija.FindAsync(id);

            if (subvencija == null)
            {
                return NotFound();
            }

            return subvencija;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutSubvencija(int id, Subvencija subvencija)
        {
            if (id != subvencija.Id)
            {
                return BadRequest();
            }

            _context.Entry(subvencija).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubvencijaExists(id))
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
        public async Task<ActionResult<Subvencija>> PostSubvencija(Subvencija subvencija)
        {
          if (_context.Subvencija == null)
          {
              return Problem("Entity set 'AgrarISContext.Subvencija'  is null.");
          }
            _context.Subvencija.Add(subvencija);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSubvencija", new { id = subvencija.Id }, subvencija);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubvencija(int id)
        {
            if (_context.Subvencija == null)
            {
                return NotFound();
            }
            var subvencija = await _context.Subvencija.FindAsync(id);
            if (subvencija == null)
            {
                return NotFound();
            }

            _context.Subvencija.Remove(subvencija);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SubvencijaExists(int id)
        {
            return (_context.Subvencija?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
