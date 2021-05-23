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
    public class CertificateTbsController : ControllerBase
    {
        private readonly INCUBATORDBContext _context;

        public CertificateTbsController(INCUBATORDBContext context)
        {
            _context = context;
        }

        // GET: api/CertificateTbs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CertificateTb>>> GetCertificateTbs()
        {
            return await _context.CertificateTbs.ToListAsync();
        }

        // GET: api/CertificateTbs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CertificateTb>> GetCertificateTb(decimal id)
        {
            var certificateTb = await _context.CertificateTbs.FindAsync(id);

            if (certificateTb == null)
            {
                return NotFound();
            }

            return certificateTb;
        }

        // PUT: api/CertificateTbs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCertificateTb(decimal id, CertificateTb certificateTb)
        {
            if (id != certificateTb.MemberId)
            {
                return BadRequest();
            }

            _context.Entry(certificateTb).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CertificateTbExists(id))
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

        // POST: api/CertificateTbs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CertificateTb>> PostCertificateTb(CertificateTb certificateTb)
        {
            _context.CertificateTbs.Add(certificateTb);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CertificateTbExists(certificateTb.MemberId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCertificateTb", new { id = certificateTb.MemberId }, certificateTb);
        }

        // DELETE: api/CertificateTbs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CertificateTb>> DeleteCertificateTb(decimal id)
        {
            var certificateTb = await _context.CertificateTbs.FindAsync(id);
            if (certificateTb == null)
            {
                return NotFound();
            }

            _context.CertificateTbs.Remove(certificateTb);
            await _context.SaveChangesAsync();

            return certificateTb;
        }

        private bool CertificateTbExists(decimal id)
        {
            return _context.CertificateTbs.Any(e => e.MemberId == id);
        }
    }
}
