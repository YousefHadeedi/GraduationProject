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
    public class CommitteTbsController : ControllerBase
    {
        private readonly INCUBATORDBContext _context;

        public CommitteTbsController(INCUBATORDBContext context)
        {
            _context = context;
        }

        // GET: api/CommitteTbs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CommitteTb>>> GetCommitteTbs()
        {
            return await _context.CommitteTbs.ToListAsync();
        }

        // GET: api/CommitteTbs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CommitteTb>> GetCommitteTb(decimal id)
        {
            var committeTb = await _context.CommitteTbs.FindAsync(id);

            if (committeTb == null)
            {
                return NotFound();
            }

            return committeTb;
        }

        // PUT: api/CommitteTbs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCommitteTb(decimal id, CommitteTb committeTb)
        {
            if (id != committeTb.IdeaPhaseId)
            {
                return BadRequest();
            }

            _context.Entry(committeTb).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommitteTbExists(id))
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

        // POST: api/CommitteTbs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CommitteTb>> PostCommitteTb(CommitteTb committeTb)
        {
            _context.CommitteTbs.Add(committeTb);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CommitteTbExists(committeTb.IdeaPhaseId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCommitteTb", new { id = committeTb.IdeaPhaseId }, committeTb);
        }

        // DELETE: api/CommitteTbs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CommitteTb>> DeleteCommitteTb(decimal id)
        {
            var committeTb = await _context.CommitteTbs.FindAsync(id);
            if (committeTb == null)
            {
                return NotFound();
            }

            _context.CommitteTbs.Remove(committeTb);
            await _context.SaveChangesAsync();

            return committeTb;
        }

        private bool CommitteTbExists(decimal id)
        {
            return _context.CommitteTbs.Any(e => e.IdeaPhaseId == id);
        }
    }
}
