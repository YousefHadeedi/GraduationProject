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
    public class RequirementDescriptionAttachmentTbsController : ControllerBase
    {
        private readonly INCUBATORDBContext _context;

        public RequirementDescriptionAttachmentTbsController(INCUBATORDBContext context)
        {
            _context = context;
        }

        // GET: api/RequirementDescriptionAttachmentTbs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RequirementDescriptionAttachmentTb>>> GetRequirementDescriptionAttachmentTbs()
        {
            return await _context.RequirementDescriptionAttachmentTbs.ToListAsync();
        }

        // GET: api/RequirementDescriptionAttachmentTbs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RequirementDescriptionAttachmentTb>> GetRequirementDescriptionAttachmentTb(decimal id)
        {
            var requirementDescriptionAttachmentTb = await _context.RequirementDescriptionAttachmentTbs.FindAsync(id);

            if (requirementDescriptionAttachmentTb == null)
            {
                return NotFound();
            }

            return requirementDescriptionAttachmentTb;
        }

        // PUT: api/RequirementDescriptionAttachmentTbs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRequirementDescriptionAttachmentTb(decimal id, RequirementDescriptionAttachmentTb requirementDescriptionAttachmentTb)
        {
            if (id != requirementDescriptionAttachmentTb.ProjectId)
            {
                return BadRequest();
            }

            _context.Entry(requirementDescriptionAttachmentTb).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RequirementDescriptionAttachmentTbExists(id))
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

        // POST: api/RequirementDescriptionAttachmentTbs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<RequirementDescriptionAttachmentTb>> PostRequirementDescriptionAttachmentTb(RequirementDescriptionAttachmentTb requirementDescriptionAttachmentTb)
        {
            _context.RequirementDescriptionAttachmentTbs.Add(requirementDescriptionAttachmentTb);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (RequirementDescriptionAttachmentTbExists(requirementDescriptionAttachmentTb.ProjectId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetRequirementDescriptionAttachmentTb", new { id = requirementDescriptionAttachmentTb.ProjectId }, requirementDescriptionAttachmentTb);
        }

        // DELETE: api/RequirementDescriptionAttachmentTbs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RequirementDescriptionAttachmentTb>> DeleteRequirementDescriptionAttachmentTb(decimal id)
        {
            var requirementDescriptionAttachmentTb = await _context.RequirementDescriptionAttachmentTbs.FindAsync(id);
            if (requirementDescriptionAttachmentTb == null)
            {
                return NotFound();
            }

            _context.RequirementDescriptionAttachmentTbs.Remove(requirementDescriptionAttachmentTb);
            await _context.SaveChangesAsync();

            return requirementDescriptionAttachmentTb;
        }

        private bool RequirementDescriptionAttachmentTbExists(decimal id)
        {
            return _context.RequirementDescriptionAttachmentTbs.Any(e => e.ProjectId == id);
        }
    }
}
