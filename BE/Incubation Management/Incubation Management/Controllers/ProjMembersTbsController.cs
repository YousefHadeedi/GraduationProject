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
    public class ProjMembersTbsController : ControllerBase
    {
        private readonly INCUBATORDBContext _context;

        public ProjMembersTbsController(INCUBATORDBContext context)
        {
            _context = context;
        }

        // GET: api/ProjMembersTbs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjMembersTb>>> GetProjMembersTbs()
        {
            return await _context.ProjMembersTbs.ToListAsync();
        }

        // GET: api/ProjMembersTbs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProjMembersTb>> GetProjMembersTb(decimal id)
        {
            var projMembersTb = await _context.ProjMembersTbs.
                Include(projMember => projMember.Member).
                Include(projMember => projMember.UserType).
                Where(project => project.ProjectId == id).FirstOrDefaultAsync();

            if (projMembersTb == null)
            {
                return NotFound();
            }

            return projMembersTb;
        }

        // PUT: api/ProjMembersTbs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProjMembersTb(decimal id, ProjMembersTb projMembersTb)
        {
            if (id != projMembersTb.ProjectId)
            {
                return BadRequest();
            }

            _context.Entry(projMembersTb).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjMembersTbExists(id))
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

        // POST: api/ProjMembersTbs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ProjMembersTb>> PostProjMembersTb(ProjMembersTb projMembersTb)
        {
            _context.ProjMembersTbs.Add(projMembersTb);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ProjMembersTbExists(projMembersTb.ProjectId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetProjMembersTb", new { id = projMembersTb.ProjectId }, projMembersTb);
        }

        // DELETE: api/ProjMembersTbs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProjMembersTb>> DeleteProjMembersTb(decimal id)
        {
            var projMembersTb = await _context.ProjMembersTbs.FindAsync(id);
            if (projMembersTb == null)
            {
                return NotFound();
            }

            _context.ProjMembersTbs.Remove(projMembersTb);
            await _context.SaveChangesAsync();

            return projMembersTb;
        }

        private bool ProjMembersTbExists(decimal id)
        {
            return _context.ProjMembersTbs.Any(e => e.ProjectId == id);
        }
    }
}
