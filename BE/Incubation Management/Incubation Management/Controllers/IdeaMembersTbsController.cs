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
    public class IdeaMembersTbsController : ControllerBase
    {
        private readonly INCUBATORDBContext _context;

        public IdeaMembersTbsController(INCUBATORDBContext context)
        {
            _context = context;
        }

        // GET: api/IdeaMembersTbs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IdeaMembersTb>>> GetIdeaMembersTbs()
        {
            return await _context.IdeaMembersTbs.ToListAsync();
        }

        // GET: api/IdeaMembersTbs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IdeaMembersTb>> GetIdeaMembersTb(decimal id)
        {
            var ideaMembersTb = await _context.IdeaMembersTbs.FindAsync(id);

            if (ideaMembersTb == null)
            {
                return NotFound();
            }

            return ideaMembersTb;
        }

        // PUT: api/IdeaMembersTbs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIdeaMembersTb(decimal id, IdeaMembersTb ideaMembersTb)
        {
            if (id != ideaMembersTb.IdeaPhaseId)
            {
                return BadRequest();
            }

            _context.Entry(ideaMembersTb).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IdeaMembersTbExists(id))
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

        // POST: api/IdeaMembersTbs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<IdeaMembersTb>> PostIdeaMembersTb(IdeaMembersTb ideaMembersTb)
        {
            _context.IdeaMembersTbs.Add(ideaMembersTb);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (IdeaMembersTbExists(ideaMembersTb.IdeaPhaseId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetIdeaMembersTb", new { id = ideaMembersTb.IdeaPhaseId }, ideaMembersTb);
        }

        // DELETE: api/IdeaMembersTbs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<IdeaMembersTb>> DeleteIdeaMembersTb(decimal id)
        {
            var ideaMembersTb = await _context.IdeaMembersTbs.FindAsync(id);
            if (ideaMembersTb == null)
            {
                return NotFound();
            }

            _context.IdeaMembersTbs.Remove(ideaMembersTb);
            await _context.SaveChangesAsync();

            return ideaMembersTb;
        }

        private bool IdeaMembersTbExists(decimal id)
        {
            return _context.IdeaMembersTbs.Any(e => e.IdeaPhaseId == id);
        }
    }
}
