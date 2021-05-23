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
    public class MembersTbsController : ControllerBase
    {
        private readonly INCUBATORDBContext _context;

        public MembersTbsController(INCUBATORDBContext context)
        {
            _context = context;
        }

        // GET: api/MembersTbs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MembersTb>>> GetMembersTbs()
        {
            return await _context.MembersTbs.Include(member => member.ProjMembersTbs).ThenInclude(projectMember => projectMember.UserType).ToListAsync();
        }

        // GET: api/MembersTbs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MembersTb>> GetMembersTb(decimal id)
        {
            var membersTb = await _context.MembersTbs.FindAsync(id);

            if (membersTb == null)
            {
                return NotFound();
            }

            return membersTb;
        }

        // PUT: api/MembersTbs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMembersTb(decimal id, MembersTb membersTb)
        {
            if (id != membersTb.MemberId)
            {
                return BadRequest();
            }

            _context.Entry(membersTb).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MembersTbExists(id))
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

        // POST: api/MembersTbs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<MembersTb>> PostMembersTb(MembersTb membersTb)
        {
            _context.MembersTbs.Add(membersTb);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MembersTbExists(membersTb.MemberId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMembersTb", new { id = membersTb.MemberId }, membersTb);
        }

        // DELETE: api/MembersTbs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MembersTb>> DeleteMembersTb(decimal id)
        {
            var membersTb = await _context.MembersTbs.FindAsync(id);
            if (membersTb == null)
            {
                return NotFound();
            }

            _context.MembersTbs.Remove(membersTb);
            await _context.SaveChangesAsync();

            return membersTb;
        }

        private bool MembersTbExists(decimal id)
        {
            return _context.MembersTbs.Any(e => e.MemberId == id);
        }
    }
}
