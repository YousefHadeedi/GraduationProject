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
    public class EntrepreneurDeliverablesTbsController : ControllerBase
    {
        private readonly INCUBATORDBContext _context;

        public EntrepreneurDeliverablesTbsController(INCUBATORDBContext context)
        {
            _context = context;
        }

        // GET: api/EntrepreneurDeliverablesTbs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EntrepreneurDeliverablesTb>>> GetEntrepreneurDeliverablesTbs()
        {
            return await _context.EntrepreneurDeliverablesTbs.ToListAsync();
        }

        // GET: api/EntrepreneurDeliverablesTbs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EntrepreneurDeliverablesTb>> GetEntrepreneurDeliverablesTb(decimal id)
        {
            var entrepreneurDeliverablesTb = await _context.EntrepreneurDeliverablesTbs.FindAsync(id);

            if (entrepreneurDeliverablesTb == null)
            {
                return NotFound();
            }

            return entrepreneurDeliverablesTb;
        }

        // PUT: api/EntrepreneurDeliverablesTbs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEntrepreneurDeliverablesTb(decimal id, EntrepreneurDeliverablesTb entrepreneurDeliverablesTb)
        {
            if (id != entrepreneurDeliverablesTb.ProjectId)
            {
                return BadRequest();
            }

            _context.Entry(entrepreneurDeliverablesTb).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EntrepreneurDeliverablesTbExists(id))
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

        // POST: api/EntrepreneurDeliverablesTbs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<EntrepreneurDeliverablesTb>> PostEntrepreneurDeliverablesTb(EntrepreneurDeliverablesTb entrepreneurDeliverablesTb)
        {
            _context.EntrepreneurDeliverablesTbs.Add(entrepreneurDeliverablesTb);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (EntrepreneurDeliverablesTbExists(entrepreneurDeliverablesTb.ProjectId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetEntrepreneurDeliverablesTb", new { id = entrepreneurDeliverablesTb.ProjectId }, entrepreneurDeliverablesTb);
        }

        // DELETE: api/EntrepreneurDeliverablesTbs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<EntrepreneurDeliverablesTb>> DeleteEntrepreneurDeliverablesTb(decimal id)
        {
            var entrepreneurDeliverablesTb = await _context.EntrepreneurDeliverablesTbs.FindAsync(id);
            if (entrepreneurDeliverablesTb == null)
            {
                return NotFound();
            }

            _context.EntrepreneurDeliverablesTbs.Remove(entrepreneurDeliverablesTb);
            await _context.SaveChangesAsync();

            return entrepreneurDeliverablesTb;
        }

        private bool EntrepreneurDeliverablesTbExists(decimal id)
        {
            return _context.EntrepreneurDeliverablesTbs.Any(e => e.ProjectId == id);
        }
    }
}
