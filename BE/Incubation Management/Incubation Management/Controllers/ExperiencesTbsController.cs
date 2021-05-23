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
    public class ExperiencesTbsController : ControllerBase
    {
        private readonly INCUBATORDBContext _context;

        public ExperiencesTbsController(INCUBATORDBContext context)
        {
            _context = context;
        }

        // GET: api/ExperiencesTbs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExperiencesTb>>> GetExperiencesTbs()
        {
            return await _context.ExperiencesTbs.ToListAsync();
        }

        // GET: api/ExperiencesTbs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ExperiencesTb>> GetExperiencesTb(decimal id)
        {
            var experiencesTb = await _context.ExperiencesTbs.FindAsync(id);

            if (experiencesTb == null)
            {
                return NotFound();
            }

            return experiencesTb;
        }

        // PUT: api/ExperiencesTbs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExperiencesTb(decimal id, ExperiencesTb experiencesTb)
        {
            if (id != experiencesTb.MemberId)
            {
                return BadRequest();
            }

            _context.Entry(experiencesTb).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExperiencesTbExists(id))
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

        // POST: api/ExperiencesTbs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ExperiencesTb>> PostExperiencesTb(ExperiencesTb experiencesTb)
        {
            _context.ExperiencesTbs.Add(experiencesTb);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ExperiencesTbExists(experiencesTb.MemberId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetExperiencesTb", new { id = experiencesTb.MemberId }, experiencesTb);
        }

        // DELETE: api/ExperiencesTbs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ExperiencesTb>> DeleteExperiencesTb(decimal id)
        {
            var experiencesTb = await _context.ExperiencesTbs.FindAsync(id);
            if (experiencesTb == null)
            {
                return NotFound();
            }

            _context.ExperiencesTbs.Remove(experiencesTb);
            await _context.SaveChangesAsync();

            return experiencesTb;
        }

        private bool ExperiencesTbExists(decimal id)
        {
            return _context.ExperiencesTbs.Any(e => e.MemberId == id);
        }
    }
}
