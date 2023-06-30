using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AgrarIS.Data;
using AgrarIS.Models;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using AgrarIS.Dtos;

namespace AgrarIS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParcelasController : ControllerBase
    {
        private readonly AgrarISContext _context;
        private readonly IMapper _mapper;

        public ParcelasController(AgrarISContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Parcela>>> GetParcela()
        {
          if (_context.Parcela == null)
          {
              return NotFound();
          }
            return await _context.Parcela.ToListAsync();
        }


        [HttpGet("parc")]
        public async Task<ActionResult> GetParcela2()
        {

            //var par = await (from a in _context.Parcela
            //                 join b in _context.Korisnik
            //                 on a.KorisnikId equals b.Id
            //                 select new
            //                 {
            //                     parcela=a,
            //                     Korisnik=b,

            //                 }
                             
            //                 ).ToListAsync();
            var par1 = await _context.Parcela.Include(c => c.Vocnjaks).ThenInclude(p => p.PoljoprivrednoDobro).ToListAsync();
            var par = _mapper.Map<List<ParcelaDto>>(par1);
            return Ok(par);

        }







        // GET: api/Parcelas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Parcela>> GetParcela(int id)
        {
          if (_context.Parcela == null)
          {
              return NotFound();
          }
            var parcela = await _context.Parcela.FindAsync(id);

            if (parcela == null)
            {
                return NotFound();
            }

            return parcela;
        }

        // PUT: api/Parcelas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutParcela(int id, Parcela parcela)
        {
            if (id != parcela.Id)
            {
                return BadRequest();
            }

            _context.Entry(parcela).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParcelaExists(id))
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

        // POST: api/Parcelas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("creatwe")]
        public async Task<ActionResult> PostParcela(ParcelaCreateDto dto)
        {
            var parcela = new Parcela
            {
                BrojParcele = dto.BrojParcele,
                Povrsina = dto.Povrsina,
            };
            await _context.Parcela.AddAsync(parcela);
            parcela.Id = await _context.SaveChangesAsync();

            return Ok(parcela);
        }

        // DELETE: api/Parcelas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteParcela(int id)
        {
            if (_context.Parcela == null)
            {
                return NotFound();
            }
            var parcela = await _context.Parcela.FindAsync(id);
            if (parcela == null)
            {
                return NotFound();
            }

            _context.Parcela.Remove(parcela);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ParcelaExists(int id)
        {
            return (_context.Parcela?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
