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
    public class IdeaPhaseTbsController : ControllerBase
    {
        private readonly INCUBATORDBContext _context;

        public IdeaPhaseTbsController(INCUBATORDBContext context)
        {
            _context = context;
        }

        // GET: api/IdeaPhaseTbs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IdeaPhaseTb>>> GetIdeaPhaseTbs()
        {
            return await _context.IdeaPhaseTbs.Include(ideaPhase => ideaPhase.IdeaMembersTbs).ToListAsync();
        }

        // GET: api/IdeaPhaseTbs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IdeaPhaseTb>> GetIdeaPhaseTb(decimal id)
        {

            var ideaPhaseTb = await _context.IdeaPhaseTbs.
                Include(ideaPhase => ideaPhase.IdeaMembersTbs).
                Include(ideaPhase => ideaPhase.Field).
                Include(ideaPhase => ideaPhase.SuperviserTbs).
                    ThenInclude(supervisor => supervisor.Member).
                    ThenInclude(member => member.UsersTb).
                Include(ideaPhase => ideaPhase.CommitteReportsTb).
                Include(ideaPhase => ideaPhase.CommitteTbs).        
                    ThenInclude(committeeMember => committeeMember.Member).
                    ThenInclude(member => member.UsersTb).
                Include(ideaPhase => ideaPhase.IdeaAttachmentsTbs).
                Include(ideaPhase => ideaPhase.TheBusinessModelCanvasTb).
                Include(ideaPhase => ideaPhase.ProjectTbs).
                Where(ideaPhase => ideaPhase.IdeaPhaseId == id).FirstOrDefaultAsync();

            if (ideaPhaseTb == null)
            {
                return NotFound();
            }

            return ideaPhaseTb;
        }

        // PUT: api/IdeaPhaseTbs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIdeaPhaseTb(decimal id, IdeaPhaseTb ideaPhaseTb)
        {
            if (id != ideaPhaseTb.IdeaPhaseId)
            {
                return BadRequest();
            }

            _context.Entry(ideaPhaseTb).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IdeaPhaseTbExists(id))
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

        // POST: api/IdeaPhaseTbs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<IdeaPhaseTb>> PostIdeaPhaseTb(IdeaPhaseTb ideaPhaseTb)
        {
            _context.IdeaPhaseTbs.Add(ideaPhaseTb);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (IdeaPhaseTbExists(ideaPhaseTb.IdeaPhaseId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetIdeaPhaseTb", new { id = ideaPhaseTb.IdeaPhaseId }, ideaPhaseTb);
        }

        // DELETE: api/IdeaPhaseTbs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<IdeaPhaseTb>> DeleteIdeaPhaseTb(decimal id)
        {
            var ideaPhaseTb = await _context.IdeaPhaseTbs.FindAsync(id);
            if (ideaPhaseTb == null)
            {
                return NotFound();
            }

            _context.IdeaPhaseTbs.Remove(ideaPhaseTb);
            await _context.SaveChangesAsync();

            return ideaPhaseTb;
        }

        private bool IdeaPhaseTbExists(decimal id)
        {
            return _context.IdeaPhaseTbs.Any(e => e.IdeaPhaseId == id);
        }
    }
}
