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
    public class UserTypesTbsController : ControllerBase
    {
        private readonly INCUBATORDBContext _context;

        public UserTypesTbsController(INCUBATORDBContext context)
        {
            _context = context;
        }

        // GET: api/UserTypesTbs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserTypesTb>>> GetUserTypesTbs()
        {
            return await _context.UserTypesTbs.ToListAsync();
        }

        // GET: api/UserTypesTbs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserTypesTb>> GetUserTypesTb(decimal id)
        {
            var userTypesTb = await _context.UserTypesTbs.FindAsync(id);

            if (userTypesTb == null)
            {
                return NotFound();
            }

            return userTypesTb;
        }

        // PUT: api/UserTypesTbs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserTypesTb(decimal id, UserTypesTb userTypesTb)
        {
            if (id != userTypesTb.UserTypeId)
            {
                return BadRequest();
            }

            _context.Entry(userTypesTb).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserTypesTbExists(id))
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

        // POST: api/UserTypesTbs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<UserTypesTb>> PostUserTypesTb(UserTypesTb userTypesTb)
        {
            _context.UserTypesTbs.Add(userTypesTb);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UserTypesTbExists(userTypesTb.UserTypeId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUserTypesTb", new { id = userTypesTb.UserTypeId }, userTypesTb);
        }

        // DELETE: api/UserTypesTbs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserTypesTb>> DeleteUserTypesTb(decimal id)
        {
            var userTypesTb = await _context.UserTypesTbs.FindAsync(id);
            if (userTypesTb == null)
            {
                return NotFound();
            }

            _context.UserTypesTbs.Remove(userTypesTb);
            await _context.SaveChangesAsync();

            return userTypesTb;
        }

        private bool UserTypesTbExists(decimal id)
        {
            return _context.UserTypesTbs.Any(e => e.UserTypeId == id);
        }
    }
}
