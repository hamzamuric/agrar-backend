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
    public class PoljoprivrednoDobroesController : ControllerBase
    {
        private readonly AgrarISContext _context;

        public PoljoprivrednoDobroesController(AgrarISContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PoljoprivrednoDobro>>> GetPoljoprivrednoDobro()
        {
          if (_context.PoljoprivrednoDobro == null)
          {
              return NotFound();
          }
            return await _context.PoljoprivrednoDobro.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PoljoprivrednoDobro>> GetPoljoprivrednoDobro(int id)
        {
          if (_context.PoljoprivrednoDobro == null)
          {
              return NotFound();
          }
            var poljoprivrednoDobro = await _context.PoljoprivrednoDobro.FindAsync(id);

            if (poljoprivrednoDobro == null)
            {
                return NotFound();
            }

            return poljoprivrednoDobro;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPoljoprivrednoDobro(int id, PoljoprivrednoDobro poljoprivrednoDobro)
        {
            if (id != poljoprivrednoDobro.Id)
            {
                return BadRequest();
            }

            _context.Entry(poljoprivrednoDobro).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PoljoprivrednoDobroExists(id))
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
        public async Task<ActionResult<PoljoprivrednoDobro>> PostPoljoprivrednoDobro(PoljoprivrednoDobro poljoprivrednoDobro)
        {
          if (_context.PoljoprivrednoDobro == null)
          {
              return Problem("Entity set 'AgrarISContext.PoljoprivrednoDobro'  is null.");
          }
            _context.PoljoprivrednoDobro.Add(poljoprivrednoDobro);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPoljoprivrednoDobro", new { id = poljoprivrednoDobro.Id }, poljoprivrednoDobro);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePoljoprivrednoDobro(int id)
        {
            if (_context.PoljoprivrednoDobro == null)
            {
                return NotFound();
            }
            var poljoprivrednoDobro = await _context.PoljoprivrednoDobro.FindAsync(id);
            if (poljoprivrednoDobro == null)
            {
                return NotFound();
            }

            _context.PoljoprivrednoDobro.Remove(poljoprivrednoDobro);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PoljoprivrednoDobroExists(int id)
        {
            return (_context.PoljoprivrednoDobro?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
