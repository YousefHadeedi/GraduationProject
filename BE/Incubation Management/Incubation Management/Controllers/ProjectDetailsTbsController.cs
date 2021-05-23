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
    public class ProjectDetailsTbsController : ControllerBase
    {
        private readonly INCUBATORDBContext _context;

        public ProjectDetailsTbsController(INCUBATORDBContext context)
        {
            _context = context;
        }

        // GET: api/ProjectDetailsTbs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjectDetailsTb>>> GetProjectDetailsTbs()
        {
            return await _context.ProjectDetailsTbs.ToListAsync();
        }

        // GET: api/ProjectDetailsTbs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectDetailsTb>> GetProjectDetailsTb(decimal id)
        {
            var projectDetailsTb = await _context.ProjectDetailsTbs.FindAsync(id);

            if (projectDetailsTb == null)
            {
                return NotFound();
            }

            return projectDetailsTb;
        }

        // PUT: api/ProjectDetailsTbs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProjectDetailsTb(decimal id, ProjectDetailsTb projectDetailsTb)
        {
            if (id != projectDetailsTb.ProjectId)
            {
                return BadRequest();
            }

            _context.Entry(projectDetailsTb).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectDetailsTbExists(id))
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

        // POST: api/ProjectDetailsTbs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ProjectDetailsTb>> PostProjectDetailsTb(ProjectDetailsTb projectDetailsTb)
        {
            _context.ProjectDetailsTbs.Add(projectDetailsTb);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ProjectDetailsTbExists(projectDetailsTb.ProjectId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetProjectDetailsTb", new { id = projectDetailsTb.ProjectId }, projectDetailsTb);
        }

        // DELETE: api/ProjectDetailsTbs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProjectDetailsTb>> DeleteProjectDetailsTb(decimal id)
        {
            var projectDetailsTb = await _context.ProjectDetailsTbs.FindAsync(id);
            if (projectDetailsTb == null)
            {
                return NotFound();
            }

            _context.ProjectDetailsTbs.Remove(projectDetailsTb);
            await _context.SaveChangesAsync();

            return projectDetailsTb;
        }

        private bool ProjectDetailsTbExists(decimal id)
        {
            return _context.ProjectDetailsTbs.Any(e => e.ProjectId == id);
        }
    }
}
