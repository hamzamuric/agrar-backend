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
    public class PesticidsController : ControllerBase
    {
        private readonly AgrarISContext _context;

        public PesticidsController(AgrarISContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pesticid>>> GetPesticid()
        {
          if (_context.Pesticid == null)
          {
              return NotFound();
          }
            return await _context.Pesticid.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Pesticid>> GetPesticid(int id)
        {
          if (_context.Pesticid == null)
          {
              return NotFound();
          }
            var pesticid = await _context.Pesticid.FindAsync(id);

            if (pesticid == null)
            {
                return NotFound();
            }

            return pesticid;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPesticid(int id, UpdatePesticidiDto pesticid)
        {
            if (id != pesticid.Id)
            {
                return BadRequest();
            }

            var pesticidDB = _context.Pesticid.FirstOrDefault(x => x.Id == pesticid.Id);
            var pd = _context.PoljoprivrednoDobro.FirstOrDefault(x => x.Id == pesticid.PoljoprivrednoDobro.Id);

            pesticidDB.PoljoprivrednoDobros.Add(pd);
            _context.SaveChanges();
            return Ok();

            //_context.Entry(pesticid).State = EntityState.Modified;

            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!PesticidExists(id))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            //return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Pesticid>> PostPesticid(Pesticid pesticid)
        {
          if (_context.Pesticid == null)
          {
              return Problem("Entity set 'AgrarISContext.Pesticid'  is null.");
          }
            _context.Pesticid.Add(pesticid);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPesticid", new { id = pesticid.Id }, pesticid);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePesticid(int id)
        {
            if (_context.Pesticid == null)
            {
                return NotFound();
            }
            var pesticid = await _context.Pesticid.FindAsync(id);
            if (pesticid == null)
            {
                return NotFound();
            }

            _context.Pesticid.Remove(pesticid);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PesticidExists(int id)
        {
            return (_context.Pesticid?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
