using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AgrarIS.Data;
using AgrarIS.Models;
using AgrarIS.Dtos;

namespace AgrarIS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VocnjaksController : ControllerBase
    {
        private readonly AgrarISContext _context;

        public VocnjaksController(AgrarISContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vocnjak>>> GetVocnjak()
        {
          if (_context.Vocnjak == null)
          {
              return NotFound();
          }
            return await _context.Vocnjak.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Vocnjak>> GetVocnjak(int id)
        {
          if (_context.Vocnjak == null)
          {
              return NotFound();
          }
            var vocnjak = await _context.Vocnjak.FindAsync(id);

            if (vocnjak == null)
            {
                return NotFound();
            }

            return vocnjak;
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutVocnjak(int id, Vocnjak vocnjak)
        {
            if (id != vocnjak.Id)
            {
                return BadRequest();
            }

            _context.Entry(vocnjak).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VocnjakExists(id))
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
        public async Task<ActionResult> PostVocnjak(VocnjakAddDto dto)
        {
          if (_context.Vocnjak == null)
          {
              return Problem("Entity set 'AgrarISContext.Vocnjak'  is null.");
          }
            var parcela = await _context.Parcela.FirstOrDefaultAsync(p => p.Id == dto.ParcelaId);
            
           
         /*   if (parcela == null)
            {
                return BadRequest();
            }*/
            var vocnjak = new Vocnjak
            {
                Tip = dto.Tip,
                ParcelaId = dto.ParcelaId,
              //  Parcela = parcela,
            };
          // await _context.Vocnjak.AddAsync(vocnjak);
            await _context.SaveChangesAsync();
            
            return Ok(vocnjak);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVocnjak(int id)
        {
            if (_context.Vocnjak == null)
            {
                return NotFound();
            }
            var vocnjak = await _context.Vocnjak.FindAsync(id);
            if (vocnjak == null)
            {
                return NotFound();
            }

            _context.Vocnjak.Remove(vocnjak);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VocnjakExists(int id)
        {
            return (_context.Vocnjak?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
