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
    public class UsersTbsController : ControllerBase
    {
        private readonly INCUBATORDBContext _context;

        public UsersTbsController(INCUBATORDBContext context)
        {
            _context = context;
        }

        // GET: api/UsersTbs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsersTb>>> GetUsersTbs()
        {
            return await _context.UsersTbs.Include(user => user.UserType).ToListAsync();
        }

        // GET: api/UsersTbs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UsersTb>> GetUsersTb(decimal id)
        {
            var usersTb = await _context.UsersTbs.Where(user => user.MemberId == id).FirstOrDefaultAsync();

            if (usersTb == null)
            {
                return NotFound();
            }

            return usersTb;
        }

        // PUT: api/UsersTbs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsersTb(decimal id, UsersTb usersTb)
        {
            if (id != usersTb.MemberId)
            {
                return BadRequest();
            }

            _context.Entry(usersTb).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsersTbExists(id))
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

        // POST: api/UsersTbs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<UsersTb>> PostUsersTb(UsersTb usersTb)
        {
            _context.UsersTbs.Add(usersTb);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UsersTbExists(usersTb.MemberId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUsersTb", new { id = usersTb.MemberId }, usersTb);
        }

        // DELETE: api/UsersTbs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UsersTb>> DeleteUsersTb(decimal id)
        {
            var usersTb = await _context.UsersTbs.FindAsync(id);
            if (usersTb == null)
            {
                return NotFound();
            }

            _context.UsersTbs.Remove(usersTb);
            await _context.SaveChangesAsync();

            return usersTb;
        }

        private bool UsersTbExists(decimal id)
        {
            return _context.UsersTbs.Any(e => e.MemberId == id);
        }
    }
}
