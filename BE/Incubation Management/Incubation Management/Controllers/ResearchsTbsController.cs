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
    public class ResearchsTbsController : ControllerBase
    {
        private readonly INCUBATORDBContext _context;

        public ResearchsTbsController(INCUBATORDBContext context)
        {
            _context = context;
        }

        // GET: api/ResearchsTbs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResearchsTb>>> GetResearchsTbs()
        {
            return await _context.ResearchsTbs.ToListAsync();
        }

        // GET: api/ResearchsTbs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ResearchsTb>> GetResearchsTb(decimal id)
        {
            var researchsTb = await _context.ResearchsTbs.FindAsync(id);

            if (researchsTb == null)
            {
                return NotFound();
            }

            return researchsTb;
        }

        // PUT: api/ResearchsTbs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutResearchsTb(decimal id, ResearchsTb researchsTb)
        {
            if (id != researchsTb.MemberId)
            {
                return BadRequest();
            }

            _context.Entry(researchsTb).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ResearchsTbExists(id))
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

        // POST: api/ResearchsTbs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ResearchsTb>> PostResearchsTb(ResearchsTb researchsTb)
        {
            _context.ResearchsTbs.Add(researchsTb);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ResearchsTbExists(researchsTb.MemberId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetResearchsTb", new { id = researchsTb.MemberId }, researchsTb);
        }

        // DELETE: api/ResearchsTbs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ResearchsTb>> DeleteResearchsTb(decimal id)
        {
            var researchsTb = await _context.ResearchsTbs.FindAsync(id);
            if (researchsTb == null)
            {
                return NotFound();
            }

            _context.ResearchsTbs.Remove(researchsTb);
            await _context.SaveChangesAsync();

            return researchsTb;
        }

        private bool ResearchsTbExists(decimal id)
        {
            return _context.ResearchsTbs.Any(e => e.MemberId == id);
        }
    }
}
