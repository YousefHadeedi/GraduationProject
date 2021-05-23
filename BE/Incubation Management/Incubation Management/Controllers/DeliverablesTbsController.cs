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
    public class DeliverablesTbsController : ControllerBase
    {
        private readonly INCUBATORDBContext _context;

        public DeliverablesTbsController(INCUBATORDBContext context)
        {
            _context = context;
        }

        // GET: api/DeliverablesTbs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DeliverablesTb>>> GetDeliverablesTbs()
        {
            return await _context.DeliverablesTbs.ToListAsync();
        }

        // GET: api/DeliverablesTbs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DeliverablesTb>> GetDeliverablesTb(decimal id)
        {
            var deliverablesTb = await _context.DeliverablesTbs.FindAsync(id);

            if (deliverablesTb == null)
            {
                return NotFound();
            }

            return deliverablesTb;
        }

        // PUT: api/DeliverablesTbs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDeliverablesTb(decimal id, DeliverablesTb deliverablesTb)
        {
            if (id != deliverablesTb.ProjectId)
            {
                return BadRequest();
            }

            _context.Entry(deliverablesTb).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeliverablesTbExists(id))
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

        // POST: api/DeliverablesTbs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<DeliverablesTb>> PostDeliverablesTb(DeliverablesTb deliverablesTb)
        {
            _context.DeliverablesTbs.Add(deliverablesTb);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DeliverablesTbExists(deliverablesTb.ProjectId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDeliverablesTb", new { id = deliverablesTb.ProjectId }, deliverablesTb);
        }

        // DELETE: api/DeliverablesTbs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DeliverablesTb>> DeleteDeliverablesTb(decimal id)
        {
            var deliverablesTb = await _context.DeliverablesTbs.FindAsync(id);
            if (deliverablesTb == null)
            {
                return NotFound();
            }

            _context.DeliverablesTbs.Remove(deliverablesTb);
            await _context.SaveChangesAsync();

            return deliverablesTb;
        }

        private bool DeliverablesTbExists(decimal id)
        {
            return _context.DeliverablesTbs.Any(e => e.ProjectId == id);
        }
    }
}
