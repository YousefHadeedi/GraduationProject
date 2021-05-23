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
    public class ReceiptVoucherAttachmentsTbsController : ControllerBase
    {
        private readonly INCUBATORDBContext _context;

        public ReceiptVoucherAttachmentsTbsController(INCUBATORDBContext context)
        {
            _context = context;
        }

        // GET: api/ReceiptVoucherAttachmentsTbs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReceiptVoucherAttachmentsTb>>> GetReceiptVoucherAttachmentsTbs()
        {
            return await _context.ReceiptVoucherAttachmentsTbs.ToListAsync();
        }

        // GET: api/ReceiptVoucherAttachmentsTbs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReceiptVoucherAttachmentsTb>> GetReceiptVoucherAttachmentsTb(decimal id)
        {
            var receiptVoucherAttachmentsTb = await _context.ReceiptVoucherAttachmentsTbs.FindAsync(id);

            if (receiptVoucherAttachmentsTb == null)
            {
                return NotFound();
            }

            return receiptVoucherAttachmentsTb;
        }

        // PUT: api/ReceiptVoucherAttachmentsTbs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReceiptVoucherAttachmentsTb(decimal id, ReceiptVoucherAttachmentsTb receiptVoucherAttachmentsTb)
        {
            if (id != receiptVoucherAttachmentsTb.ProjectId)
            {
                return BadRequest();
            }

            _context.Entry(receiptVoucherAttachmentsTb).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReceiptVoucherAttachmentsTbExists(id))
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

        // POST: api/ReceiptVoucherAttachmentsTbs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ReceiptVoucherAttachmentsTb>> PostReceiptVoucherAttachmentsTb(ReceiptVoucherAttachmentsTb receiptVoucherAttachmentsTb)
        {
            _context.ReceiptVoucherAttachmentsTbs.Add(receiptVoucherAttachmentsTb);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ReceiptVoucherAttachmentsTbExists(receiptVoucherAttachmentsTb.ProjectId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetReceiptVoucherAttachmentsTb", new { id = receiptVoucherAttachmentsTb.ProjectId }, receiptVoucherAttachmentsTb);
        }

        // DELETE: api/ReceiptVoucherAttachmentsTbs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ReceiptVoucherAttachmentsTb>> DeleteReceiptVoucherAttachmentsTb(decimal id)
        {
            var receiptVoucherAttachmentsTb = await _context.ReceiptVoucherAttachmentsTbs.FindAsync(id);
            if (receiptVoucherAttachmentsTb == null)
            {
                return NotFound();
            }

            _context.ReceiptVoucherAttachmentsTbs.Remove(receiptVoucherAttachmentsTb);
            await _context.SaveChangesAsync();

            return receiptVoucherAttachmentsTb;
        }

        private bool ReceiptVoucherAttachmentsTbExists(decimal id)
        {
            return _context.ReceiptVoucherAttachmentsTbs.Any(e => e.ProjectId == id);
        }
    }
}
