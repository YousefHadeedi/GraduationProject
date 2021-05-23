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
    public class ProjectTbsController : ControllerBase
    {
        private readonly INCUBATORDBContext _context;

        public ProjectTbsController(INCUBATORDBContext context)
        {
            _context = context;
        }

        // GET: api/ProjectTbs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjectTb>>> GetProjectTbs()
        {
            return await _context.ProjectTbs.Include(project => project.Field).Include(project => project.IdeaPhase).ThenInclude(ideaphase => ideaphase.CommitteReportsTb).ToListAsync();
        }

        // GET: api/ProjectTbs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectTb>> GetProjectTb(decimal id)
        {
            var projectTb = await _context.ProjectTbs.Include(project => project.Field).
                Include(project => project.IdeaPhase).
                Include(project => project.MeetingReportsTbs).
                Include(project => project.ProjectAttachmentsTbs).
                Include(project => project.ProjectDetailsTb).
                Include(project => project.ProjMembersTbs).
                Include(project => project.FinanceRequirementsTbs).
                Include(project => project.EntrepreneurDeliverablesTbs).
                Include(project => project.EntrepreneurDeliverablesAttachmentsTbs).
                Include(project => project.ReceiptVoucherAttachmentsTbs).
                Include(project => project.ReceivedRequirementAttachmentTbs).
                Include(project => project.RequirementDescriptionAttachmentTbs).
                Where(project => project.ProjectId == id).FirstOrDefaultAsync();

            if (projectTb == null)
            {
                return NotFound();
            }

            return projectTb;
        }
        // GET: api/ProjectTbs/ideaProject/5
        [HttpGet("ideaProject/{id}")]
        public async Task<ActionResult<ProjectTb>> GetProjectTbByIdeaID(decimal id)
        {
            var projectTb = await _context.ProjectTbs.Include(project => project.Field).
                Include(project => project.IdeaPhase).
                Include(project => project.MeetingReportsTbs).
                Include(project => project.ProjectAttachmentsTbs).
                Include(project => project.ProjectDetailsTb).
                Include(project => project.ProjMembersTbs).
                    ThenInclude(projectMember => projectMember.Member).
                    ThenInclude(projectMember => projectMember.UsersTb).
                        ThenInclude(user => user.UserType).
                Include(project => project.FinanceRequirementsTbs).
                Include(project => project.EntrepreneurDeliverablesTbs).
                Include(project => project.EntrepreneurDeliverablesAttachmentsTbs).
                Include(project => project.ReceiptVoucherAttachmentsTbs).
                Include(project => project.ReceivedRequirementAttachmentTbs).
                Include(project => project.RequirementDescriptionAttachmentTbs).
                Where(project => project.IdeaPhaseId == id).FirstOrDefaultAsync();

            if (projectTb == null)
            {
                return NotFound();
            }

            return projectTb;
        }

        // PUT: api/ProjectTbs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProjectTb(decimal id, ProjectTb projectTb)
        {
            if (id != projectTb.ProjectId)
            {
                return BadRequest();
            }

            _context.Entry(projectTb).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectTbExists(id))
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

        // POST: api/ProjectTbs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ProjectTb>> PostProjectTb(ProjectTb projectTb)
        {
            _context.ProjectTbs.Add(projectTb);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ProjectTbExists(projectTb.ProjectId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetProjectTb", new { id = projectTb.ProjectId }, projectTb);
        }

        // DELETE: api/ProjectTbs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProjectTb>> DeleteProjectTb(decimal id)
        {
            var projectTb = await _context.ProjectTbs.FindAsync(id);
            if (projectTb == null)
            {
                return NotFound();
            }

            _context.ProjectTbs.Remove(projectTb);
            await _context.SaveChangesAsync();

            return projectTb;
        }

        private bool ProjectTbExists(decimal id)
        {
            return _context.ProjectTbs.Any(e => e.ProjectId == id);
        }
    }
}
