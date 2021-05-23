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
    public class CertificationTypesTbsController : ControllerBase
    {
        private readonly INCUBATORDBContext _context;

        public CertificationTypesTbsController(INCUBATORDBContext context)
        {
            _context = context;
        }

        // GET: api/CertificationTypesTbs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CertificationTypesTb>>> GetCertificationTypesTbs()
        {
            return await _context.CertificationTypesTbs.ToListAsync();
        }

        // GET: api/CertificationTypesTbs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CertificationTypesTb>> GetCertificationTypesTb(decimal id)
        {
            var certificationTypesTb = await _context.CertificationTypesTbs.FindAsync(id);

            if (certificationTypesTb == null)
            {
                return NotFound();
            }

            return certificationTypesTb;
        }

        // PUT: api/CertificationTypesTbs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCertificationTypesTb(decimal id, CertificationTypesTb certificationTypesTb)
        {
            if (id != certificationTypesTb.CertificationTypeId)
            {
                return BadRequest();
            }

            _context.Entry(certificationTypesTb).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CertificationTypesTbExists(id))
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

        // POST: api/CertificationTypesTbs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CertificationTypesTb>> PostCertificationTypesTb(CertificationTypesTb certificationTypesTb)
        {
            _context.CertificationTypesTbs.Add(certificationTypesTb);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CertificationTypesTbExists(certificationTypesTb.CertificationTypeId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCertificationTypesTb", new { id = certificationTypesTb.CertificationTypeId }, certificationTypesTb);
        }

        // DELETE: api/CertificationTypesTbs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CertificationTypesTb>> DeleteCertificationTypesTb(decimal id)
        {
            var certificationTypesTb = await _context.CertificationTypesTbs.FindAsync(id);
            if (certificationTypesTb == null)
            {
                return NotFound();
            }

            _context.CertificationTypesTbs.Remove(certificationTypesTb);
            await _context.SaveChangesAsync();

            return certificationTypesTb;
        }

        private bool CertificationTypesTbExists(decimal id)
        {
            return _context.CertificationTypesTbs.Any(e => e.CertificationTypeId == id);
        }
    }
}
