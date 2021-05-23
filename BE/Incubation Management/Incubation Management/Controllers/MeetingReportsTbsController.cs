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
    public class MeetingReportsTbsController : ControllerBase
    {
        private readonly INCUBATORDBContext _context;

        public MeetingReportsTbsController(INCUBATORDBContext context)
        {
            _context = context;
        }

        // GET: api/MeetingReportsTbs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MeetingReportsTb>>> GetMeetingReportsTbs()
        {
            return await _context.MeetingReportsTbs.ToListAsync();
        }

        // GET: api/MeetingReportsTbs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MeetingReportsTb>> GetMeetingReportsTb(decimal id)
        {
            var meetingReportsTb = await _context.MeetingReportsTbs.FindAsync(id);

            if (meetingReportsTb == null)
            {
                return NotFound();
            }

            return meetingReportsTb;
        }

        // PUT: api/MeetingReportsTbs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMeetingReportsTb(decimal id, MeetingReportsTb meetingReportsTb)
        {
            if (id != meetingReportsTb.ProjectId)
            {
                return BadRequest();
            }

            _context.Entry(meetingReportsTb).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MeetingReportsTbExists(id))
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

        // POST: api/MeetingReportsTbs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<MeetingReportsTb>> PostMeetingReportsTb(MeetingReportsTb meetingReportsTb)
        {
            _context.MeetingReportsTbs.Add(meetingReportsTb);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MeetingReportsTbExists(meetingReportsTb.ProjectId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMeetingReportsTb", new { id = meetingReportsTb.ProjectId }, meetingReportsTb);
        }

        // DELETE: api/MeetingReportsTbs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MeetingReportsTb>> DeleteMeetingReportsTb(decimal id)
        {
            var meetingReportsTb = await _context.MeetingReportsTbs.FindAsync(id);
            if (meetingReportsTb == null)
            {
                return NotFound();
            }

            _context.MeetingReportsTbs.Remove(meetingReportsTb);
            await _context.SaveChangesAsync();

            return meetingReportsTb;
        }

        private bool MeetingReportsTbExists(decimal id)
        {
            return _context.MeetingReportsTbs.Any(e => e.ProjectId == id);
        }
    }
}
