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
    public class IdeaAttachmentsTbsController : ControllerBase
    {
        private readonly INCUBATORDBContext _context;

        public IdeaAttachmentsTbsController(INCUBATORDBContext context)
        {
            _context = context;
        }

        // GET: api/IdeaAttachmentsTbs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IdeaAttachmentsTb>>> GetIdeaAttachmentsTbs()
        {
            return await _context.IdeaAttachmentsTbs.ToListAsync();
        }

        // GET: api/IdeaAttachmentsTbs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IdeaAttachmentsTb>> GetIdeaAttachmentsTb(decimal id)
        {
            var ideaAttachmentsTb = await _context.IdeaAttachmentsTbs.FindAsync(id);

            if (ideaAttachmentsTb == null)
            {
                return NotFound();
            }

            return ideaAttachmentsTb;
        }

        // PUT: api/IdeaAttachmentsTbs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIdeaAttachmentsTb(decimal id, IdeaAttachmentsTb ideaAttachmentsTb)
        {
            if (id != ideaAttachmentsTb.IdeaPhaseId)
            {
                return BadRequest();
            }

            _context.Entry(ideaAttachmentsTb).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IdeaAttachmentsTbExists(id))
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

        // POST: api/IdeaAttachmentsTbs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<IdeaAttachmentsTb>> PostIdeaAttachmentsTb(IdeaAttachmentsTb ideaAttachmentsTb)
        {
            _context.IdeaAttachmentsTbs.Add(ideaAttachmentsTb);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (IdeaAttachmentsTbExists(ideaAttachmentsTb.IdeaPhaseId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetIdeaAttachmentsTb", new { id = ideaAttachmentsTb.IdeaPhaseId }, ideaAttachmentsTb);
        }

        // DELETE: api/IdeaAttachmentsTbs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<IdeaAttachmentsTb>> DeleteIdeaAttachmentsTb(decimal id)
        {
            var ideaAttachmentsTb = await _context.IdeaAttachmentsTbs.FindAsync(id);
            if (ideaAttachmentsTb == null)
            {
                return NotFound();
            }

            _context.IdeaAttachmentsTbs.Remove(ideaAttachmentsTb);
            await _context.SaveChangesAsync();

            return ideaAttachmentsTb;
        }

        private bool IdeaAttachmentsTbExists(decimal id)
        {
            return _context.IdeaAttachmentsTbs.Any(e => e.IdeaPhaseId == id);
        }
    }
}
