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
    public class SuperviserTbsController : ControllerBase
    {
        private readonly INCUBATORDBContext _context;

        public SuperviserTbsController(INCUBATORDBContext context)
        {
            _context = context;
        }

        // GET: api/SuperviserTbs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SuperviserTb>>> GetSuperviserTbs()
        {
            return await _context.SuperviserTbs.ToListAsync();
        }

        // GET: api/SuperviserTbs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SuperviserTb>> GetSuperviserTb(decimal id)
        {
            var superviserTb = await _context.SuperviserTbs.FindAsync(id);

            if (superviserTb == null)
            {
                return NotFound();
            }

            return superviserTb;
        }

        // PUT: api/SuperviserTbs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSuperviserTb(decimal id, SuperviserTb superviserTb)
        {
            if (id != superviserTb.IdeaPhaseId)
            {
                return BadRequest();
            }

            _context.Entry(superviserTb).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SuperviserTbExists(id))
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

        // POST: api/SuperviserTbs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<SuperviserTb>> PostSuperviserTb(SuperviserTb superviserTb)
        {
            _context.SuperviserTbs.Add(superviserTb);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SuperviserTbExists(superviserTb.IdeaPhaseId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetSuperviserTb", new { id = superviserTb.IdeaPhaseId }, superviserTb);
        }

        // DELETE: api/SuperviserTbs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SuperviserTb>> DeleteSuperviserTb(decimal id)
        {
            var superviserTb = await _context.SuperviserTbs.FindAsync(id);
            if (superviserTb == null)
            {
                return NotFound();
            }

            _context.SuperviserTbs.Remove(superviserTb);
            await _context.SaveChangesAsync();

            return superviserTb;
        }

        private bool SuperviserTbExists(decimal id)
        {
            return _context.SuperviserTbs.Any(e => e.IdeaPhaseId == id);
        }
    }
}
