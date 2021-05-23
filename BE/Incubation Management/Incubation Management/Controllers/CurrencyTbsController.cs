using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Incubation_Management.Models;

namespace Incubation_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyTbsController : ControllerBase
    {
        private readonly INCUBATORDBContext _context;

        public CurrencyTbsController(INCUBATORDBContext context)
        {
            _context = context;
        }

        // GET: api/CurrencyTbs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CurrencyTb>>> GetCurrencyTbs()
        {
            return await _context.CurrencyTbs.ToListAsync();
        }

        // GET: api/CurrencyTbs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CurrencyTb>> GetCurrencyTb(decimal id)
        {
            var currencyTb = await _context.CurrencyTbs.FindAsync(id);

            if (currencyTb == null)
            {
                return NotFound();
            }

            return currencyTb;
        }

        // PUT: api/CurrencyTbs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCurrencyTb(decimal id, CurrencyTb currencyTb)
        {
            if (id != currencyTb.CurrencyId)
            {
                return BadRequest();
            }

            _context.Entry(currencyTb).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CurrencyTbExists(id))
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

        // POST: api/CurrencyTbs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CurrencyTb>> PostCurrencyTb(CurrencyTb currencyTb)
        {
            _context.CurrencyTbs.Add(currencyTb);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CurrencyTbExists(currencyTb.CurrencyId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCurrencyTb", new { id = currencyTb.CurrencyId }, currencyTb);
        }

        // DELETE: api/CurrencyTbs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CurrencyTb>> DeleteCurrencyTb(decimal id)
        {
            var currencyTb = await _context.CurrencyTbs.FindAsync(id);
            if (currencyTb == null)
            {
                return NotFound();
            }

            _context.CurrencyTbs.Remove(currencyTb);
            await _context.SaveChangesAsync();

            return currencyTb;
        }

        private bool CurrencyTbExists(decimal id)
        {
            return _context.CurrencyTbs.Any(e => e.CurrencyId == id);
        }
    }
}
