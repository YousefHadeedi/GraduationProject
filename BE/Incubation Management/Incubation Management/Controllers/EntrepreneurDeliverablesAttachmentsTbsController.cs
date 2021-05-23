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
    public class EntrepreneurDeliverablesAttachmentsTbsController : ControllerBase
    {
        private readonly INCUBATORDBContext _context;

        public EntrepreneurDeliverablesAttachmentsTbsController(INCUBATORDBContext context)
        {
            _context = context;
        }

        // GET: api/EntrepreneurDeliverablesAttachmentsTbs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EntrepreneurDeliverablesAttachmentsTb>>> GetEntrepreneurDeliverablesAttachmentsTbs()
        {
            return await _context.EntrepreneurDeliverablesAttachmentsTbs.ToListAsync();
        }

        // GET: api/EntrepreneurDeliverablesAttachmentsTbs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EntrepreneurDeliverablesAttachmentsTb>> GetEntrepreneurDeliverablesAttachmentsTb(decimal id)
        {
            var entrepreneurDeliverablesAttachmentsTb = await _context.EntrepreneurDeliverablesAttachmentsTbs.FindAsync(id);

            if (entrepreneurDeliverablesAttachmentsTb == null)
            {
                return NotFound();
            }

            return entrepreneurDeliverablesAttachmentsTb;
        }

        // PUT: api/EntrepreneurDeliverablesAttachmentsTbs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEntrepreneurDeliverablesAttachmentsTb(decimal id, EntrepreneurDeliverablesAttachmentsTb entrepreneurDeliverablesAttachmentsTb)
        {
            if (id != entrepreneurDeliverablesAttachmentsTb.ProjectId)
            {
                return BadRequest();
            }

            _context.Entry(entrepreneurDeliverablesAttachmentsTb).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EntrepreneurDeliverablesAttachmentsTbExists(id))
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

        // POST: api/EntrepreneurDeliverablesAttachmentsTbs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<EntrepreneurDeliverablesAttachmentsTb>> PostEntrepreneurDeliverablesAttachmentsTb(EntrepreneurDeliverablesAttachmentsTb entrepreneurDeliverablesAttachmentsTb)
        {
            _context.EntrepreneurDeliverablesAttachmentsTbs.Add(entrepreneurDeliverablesAttachmentsTb);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (EntrepreneurDeliverablesAttachmentsTbExists(entrepreneurDeliverablesAttachmentsTb.ProjectId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetEntrepreneurDeliverablesAttachmentsTb", new { id = entrepreneurDeliverablesAttachmentsTb.ProjectId }, entrepreneurDeliverablesAttachmentsTb);
        }

        // DELETE: api/EntrepreneurDeliverablesAttachmentsTbs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<EntrepreneurDeliverablesAttachmentsTb>> DeleteEntrepreneurDeliverablesAttachmentsTb(decimal id)
        {
            var entrepreneurDeliverablesAttachmentsTb = await _context.EntrepreneurDeliverablesAttachmentsTbs.FindAsync(id);
            if (entrepreneurDeliverablesAttachmentsTb == null)
            {
                return NotFound();
            }

            _context.EntrepreneurDeliverablesAttachmentsTbs.Remove(entrepreneurDeliverablesAttachmentsTb);
            await _context.SaveChangesAsync();

            return entrepreneurDeliverablesAttachmentsTb;
        }

        private bool EntrepreneurDeliverablesAttachmentsTbExists(decimal id)
        {
            return _context.EntrepreneurDeliverablesAttachmentsTbs.Any(e => e.ProjectId == id);
        }
    }
}
