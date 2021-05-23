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
    public class ReceivedRequirementAttachmentTbsController : ControllerBase
    {
        private readonly INCUBATORDBContext _context;

        public ReceivedRequirementAttachmentTbsController(INCUBATORDBContext context)
        {
            _context = context;
        }

        // GET: api/ReceivedRequirementAttachmentTbs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReceivedRequirementAttachmentTb>>> GetReceivedRequirementAttachmentTbs()
        {
            return await _context.ReceivedRequirementAttachmentTbs.ToListAsync();
        }

        // GET: api/ReceivedRequirementAttachmentTbs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReceivedRequirementAttachmentTb>> GetReceivedRequirementAttachmentTb(decimal id)
        {
            var receivedRequirementAttachmentTb = await _context.ReceivedRequirementAttachmentTbs.FindAsync(id);

            if (receivedRequirementAttachmentTb == null)
            {
                return NotFound();
            }

            return receivedRequirementAttachmentTb;
        }

        // PUT: api/ReceivedRequirementAttachmentTbs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReceivedRequirementAttachmentTb(decimal id, ReceivedRequirementAttachmentTb receivedRequirementAttachmentTb)
        {
            if (id != receivedRequirementAttachmentTb.ProjectId)
            {
                return BadRequest();
            }

            _context.Entry(receivedRequirementAttachmentTb).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReceivedRequirementAttachmentTbExists(id))
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

        // POST: api/ReceivedRequirementAttachmentTbs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ReceivedRequirementAttachmentTb>> PostReceivedRequirementAttachmentTb(ReceivedRequirementAttachmentTb receivedRequirementAttachmentTb)
        {
            _context.ReceivedRequirementAttachmentTbs.Add(receivedRequirementAttachmentTb);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ReceivedRequirementAttachmentTbExists(receivedRequirementAttachmentTb.ProjectId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetReceivedRequirementAttachmentTb", new { id = receivedRequirementAttachmentTb.ProjectId }, receivedRequirementAttachmentTb);
        }

        // DELETE: api/ReceivedRequirementAttachmentTbs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ReceivedRequirementAttachmentTb>> DeleteReceivedRequirementAttachmentTb(decimal id)
        {
            var receivedRequirementAttachmentTb = await _context.ReceivedRequirementAttachmentTbs.FindAsync(id);
            if (receivedRequirementAttachmentTb == null)
            {
                return NotFound();
            }

            _context.ReceivedRequirementAttachmentTbs.Remove(receivedRequirementAttachmentTb);
            await _context.SaveChangesAsync();

            return receivedRequirementAttachmentTb;
        }

        private bool ReceivedRequirementAttachmentTbExists(decimal id)
        {
            return _context.ReceivedRequirementAttachmentTbs.Any(e => e.ProjectId == id);
        }
    }
}
