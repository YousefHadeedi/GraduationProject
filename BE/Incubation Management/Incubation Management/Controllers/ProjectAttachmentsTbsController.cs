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
    public class ProjectAttachmentsTbsController : ControllerBase
    {
        private readonly INCUBATORDBContext _context;

        public ProjectAttachmentsTbsController(INCUBATORDBContext context)
        {
            _context = context;
        }

        // GET: api/ProjectAttachmentsTbs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjectAttachmentsTb>>> GetProjectAttachmentsTbs()
        {
            return await _context.ProjectAttachmentsTbs.ToListAsync();
        }

        // GET: api/ProjectAttachmentsTbs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectAttachmentsTb>> GetProjectAttachmentsTb(decimal id)
        {
            var projectAttachmentsTb = await _context.ProjectAttachmentsTbs.FindAsync(id);

            if (projectAttachmentsTb == null)
            {
                return NotFound();
            }

            return projectAttachmentsTb;
        }

        // PUT: api/ProjectAttachmentsTbs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProjectAttachmentsTb(decimal id, ProjectAttachmentsTb projectAttachmentsTb)
        {
            if (id != projectAttachmentsTb.ProjectId)
            {
                return BadRequest();
            }

            _context.Entry(projectAttachmentsTb).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectAttachmentsTbExists(id))
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

        // POST: api/ProjectAttachmentsTbs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ProjectAttachmentsTb>> PostProjectAttachmentsTb(ProjectAttachmentsTb projectAttachmentsTb)
        {
            _context.ProjectAttachmentsTbs.Add(projectAttachmentsTb);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ProjectAttachmentsTbExists(projectAttachmentsTb.ProjectId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetProjectAttachmentsTb", new { id = projectAttachmentsTb.ProjectId }, projectAttachmentsTb);
        }

        // DELETE: api/ProjectAttachmentsTbs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProjectAttachmentsTb>> DeleteProjectAttachmentsTb(decimal id)
        {
            var projectAttachmentsTb = await _context.ProjectAttachmentsTbs.FindAsync(id);
            if (projectAttachmentsTb == null)
            {
                return NotFound();
            }

            _context.ProjectAttachmentsTbs.Remove(projectAttachmentsTb);
            await _context.SaveChangesAsync();

            return projectAttachmentsTb;
        }

        private bool ProjectAttachmentsTbExists(decimal id)
        {
            return _context.ProjectAttachmentsTbs.Any(e => e.ProjectId == id);
        }
    }
}
