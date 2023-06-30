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
    public class KorisniksController : ControllerBase
    {
        private readonly AgrarISContext _context;

        public KorisniksController(AgrarISContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Korisnik>>> GetKorisnik()
        {
          if (_context.Korisnik == null)
          {
              return NotFound();
          }
            return await _context.Korisnik.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Korisnik>> GetKorisnik(int id)
        {
          if (_context.Korisnik == null)
          {
              return NotFound();
          }
            var korisnik = await _context.Korisnik.FindAsync(id);

            if (korisnik == null)
            {
                return NotFound();
            }

            return korisnik;
        }

        [HttpPut("updateKorisnik")]
        public async Task<IActionResult> PutKorisnik(KorisnikDto korisnik)
        {


            var k=await _context.Korisnik.FirstOrDefaultAsync(a=>a.Id==korisnik.Id);



            k.Ime=korisnik.Ime;
            k.Prezime=korisnik.Prezime;


            _context.Korisnik.Update(k);

            _context.SaveChangesAsync();

            return Ok();






          /*  if (id != korisnik.Id)
            {
                return BadRequest();
            }

            _context.Entry(korisnik).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KorisnikExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
          */
        }

        [HttpPost]
        public async Task<ActionResult<Korisnik>> PostKorisnik(Korisnik korisnik)
        {
          if (_context.Korisnik == null)
          {
              return Problem("Entity set 'AgrarISContext.Korisnik'  is null.");
          }
            _context.Korisnik.Add(korisnik);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetKorisnik", new { id = korisnik.Id }, korisnik);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKorisnik(int id)
        {
            if (_context.Korisnik == null)
            {
                return NotFound();
            }
            var korisnik = await _context.Korisnik.FindAsync(id);
            if (korisnik == null)
            {
                return NotFound();
            }

            _context.Korisnik.Remove(korisnik);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool KorisnikExists(int id)
        {
            return (_context.Korisnik?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
