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
    public class TheBusinessModelCanvasTbsController : ControllerBase
    {
        private readonly INCUBATORDBContext _context;

        public TheBusinessModelCanvasTbsController(INCUBATORDBContext context)
        {
            _context = context;
        }

        // GET: api/TheBusinessModelCanvasTbs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TheBusinessModelCanvasTb>>> GetTheBusinessModelCanvasTbs()
        {
            return await _context.TheBusinessModelCanvasTbs.ToListAsync();
        }

        // GET: api/TheBusinessModelCanvasTbs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TheBusinessModelCanvasTb>> GetTheBusinessModelCanvasTb(decimal id)
        {
            var theBusinessModelCanvasTb = await _context.TheBusinessModelCanvasTbs.FindAsync(id);

            if (theBusinessModelCanvasTb == null)
            {
                return NotFound();
            }

            return theBusinessModelCanvasTb;
        }

        // PUT: api/TheBusinessModelCanvasTbs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTheBusinessModelCanvasTb(decimal id, TheBusinessModelCanvasTb theBusinessModelCanvasTb)
        {
            if (id != theBusinessModelCanvasTb.IdeaPhaseId)
            {
                return BadRequest();
            }

            _context.Entry(theBusinessModelCanvasTb).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TheBusinessModelCanvasTbExists(id))
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

        // POST: api/TheBusinessModelCanvasTbs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TheBusinessModelCanvasTb>> PostTheBusinessModelCanvasTb(TheBusinessModelCanvasTb theBusinessModelCanvasTb)
        {
            _context.TheBusinessModelCanvasTbs.Add(theBusinessModelCanvasTb);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TheBusinessModelCanvasTbExists(theBusinessModelCanvasTb.IdeaPhaseId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTheBusinessModelCanvasTb", new { id = theBusinessModelCanvasTb.IdeaPhaseId }, theBusinessModelCanvasTb);
        }

        // DELETE: api/TheBusinessModelCanvasTbs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TheBusinessModelCanvasTb>> DeleteTheBusinessModelCanvasTb(decimal id)
        {
            var theBusinessModelCanvasTb = await _context.TheBusinessModelCanvasTbs.FindAsync(id);
            if (theBusinessModelCanvasTb == null)
            {
                return NotFound();
            }

            _context.TheBusinessModelCanvasTbs.Remove(theBusinessModelCanvasTb);
            await _context.SaveChangesAsync();

            return theBusinessModelCanvasTb;
        }

        private bool TheBusinessModelCanvasTbExists(decimal id)
        {
            return _context.TheBusinessModelCanvasTbs.Any(e => e.IdeaPhaseId == id);
        }
    }
}
