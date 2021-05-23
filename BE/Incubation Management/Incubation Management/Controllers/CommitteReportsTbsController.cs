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
    public class CommitteReportsTbsController : ControllerBase
    {
        private readonly INCUBATORDBContext _context;

        public CommitteReportsTbsController(INCUBATORDBContext context)
        {
            _context = context;
        }

        // GET: api/CommitteReportsTbs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CommitteReportsTb>>> GetCommitteReportsTbs()
        {
            return await _context.CommitteReportsTbs.ToListAsync();
        }

        // GET: api/CommitteReportsTbs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CommitteReportsTb>> GetCommitteReportsTb(decimal id)
        {
            var committeReportsTb = await _context.CommitteReportsTbs.FindAsync(id);

            if (committeReportsTb == null)
            {
                return NotFound();
            }

            return committeReportsTb;
        }

        // PUT: api/CommitteReportsTbs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCommitteReportsTb(decimal id, CommitteReportsTb committeReportsTb)
        {
            if (id != committeReportsTb.IdeaPhaseId)
            {
                return BadRequest();
            }

            _context.Entry(committeReportsTb).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommitteReportsTbExists(id))
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

        // POST: api/CommitteReportsTbs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CommitteReportsTb>> PostCommitteReportsTb(CommitteReportsTb committeReportsTb)
        {
            _context.CommitteReportsTbs.Add(committeReportsTb);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CommitteReportsTbExists(committeReportsTb.IdeaPhaseId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCommitteReportsTb", new { id = committeReportsTb.IdeaPhaseId }, committeReportsTb);
        }

        // DELETE: api/CommitteReportsTbs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CommitteReportsTb>> DeleteCommitteReportsTb(decimal id)
        {
            var committeReportsTb = await _context.CommitteReportsTbs.FindAsync(id);
            if (committeReportsTb == null)
            {
                return NotFound();
            }

            _context.CommitteReportsTbs.Remove(committeReportsTb);
            await _context.SaveChangesAsync();

            return committeReportsTb;
        }

        private bool CommitteReportsTbExists(decimal id)
        {
            return _context.CommitteReportsTbs.Any(e => e.IdeaPhaseId == id);
        }
    }
}
