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
    public class FinanceRequirementsTbsController : ControllerBase
    {
        private readonly INCUBATORDBContext _context;

        public FinanceRequirementsTbsController(INCUBATORDBContext context)
        {
            _context = context;
        }

        // GET: api/FinanceRequirementsTbs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FinanceRequirementsTb>>> GetFinanceRequirementsTbs()
        {
            return await _context.FinanceRequirementsTbs.ToListAsync();
        }

        // GET: api/FinanceRequirementsTbs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FinanceRequirementsTb>> GetFinanceRequirementsTb(decimal id)
        {
            var financeRequirementsTb = await _context.FinanceRequirementsTbs.FindAsync(id);

            if (financeRequirementsTb == null)
            {
                return NotFound();
            }

            return financeRequirementsTb;
        }

        // PUT: api/FinanceRequirementsTbs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFinanceRequirementsTb(decimal id, FinanceRequirementsTb financeRequirementsTb)
        {
            if (id != financeRequirementsTb.ProjectId)
            {
                return BadRequest();
            }

            _context.Entry(financeRequirementsTb).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FinanceRequirementsTbExists(id))
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

        // POST: api/FinanceRequirementsTbs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<FinanceRequirementsTb>> PostFinanceRequirementsTb(FinanceRequirementsTb financeRequirementsTb)
        {
            _context.FinanceRequirementsTbs.Add(financeRequirementsTb);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (FinanceRequirementsTbExists(financeRequirementsTb.ProjectId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetFinanceRequirementsTb", new { id = financeRequirementsTb.ProjectId }, financeRequirementsTb);
        }

        // DELETE: api/FinanceRequirementsTbs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<FinanceRequirementsTb>> DeleteFinanceRequirementsTb(decimal id)
        {
            var financeRequirementsTb = await _context.FinanceRequirementsTbs.FindAsync(id);
            if (financeRequirementsTb == null)
            {
                return NotFound();
            }

            _context.FinanceRequirementsTbs.Remove(financeRequirementsTb);
            await _context.SaveChangesAsync();

            return financeRequirementsTb;
        }

        private bool FinanceRequirementsTbExists(decimal id)
        {
            return _context.FinanceRequirementsTbs.Any(e => e.ProjectId == id);
        }
    }
}
