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
    public class FieldsTbsController : ControllerBase
    {
        private readonly INCUBATORDBContext _context;

        public FieldsTbsController(INCUBATORDBContext context)
        {
            _context = context;
        }

        // GET: api/FieldsTbs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FieldsTb>>> GetFieldsTbs()
        {
            return await _context.FieldsTbs.ToListAsync();
        }

        // GET: api/FieldsTbs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FieldsTb>> GetFieldsTb(decimal id)
        {
            var fieldsTb = await _context.FieldsTbs.FindAsync(id);

            if (fieldsTb == null)
            {
                return NotFound();
            }

            return fieldsTb;
        }

        // PUT: api/FieldsTbs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFieldsTb(decimal id, FieldsTb fieldsTb)
        {
            if (id != fieldsTb.FieldId)
            {
                return BadRequest();
            }

            _context.Entry(fieldsTb).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FieldsTbExists(id))
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

        // POST: api/FieldsTbs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<FieldsTb>> PostFieldsTb(FieldsTb fieldsTb)
        {
            _context.FieldsTbs.Add(fieldsTb);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (FieldsTbExists(fieldsTb.FieldId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetFieldsTb", new { id = fieldsTb.FieldId }, fieldsTb);
        }

        // DELETE: api/FieldsTbs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<FieldsTb>> DeleteFieldsTb(decimal id)
        {
            var fieldsTb = await _context.FieldsTbs.FindAsync(id);
            if (fieldsTb == null)
            {
                return NotFound();
            }

            _context.FieldsTbs.Remove(fieldsTb);
            await _context.SaveChangesAsync();

            return fieldsTb;
        }

        private bool FieldsTbExists(decimal id)
        {
            return _context.FieldsTbs.Any(e => e.FieldId == id);
        }
    }
}
