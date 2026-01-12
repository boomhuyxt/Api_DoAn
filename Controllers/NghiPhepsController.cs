using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api_DoAn.DATAS;
using Api_DoAn.Models;

namespace Api_DoAn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NghiPhepsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public NghiPhepsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/NghiPheps
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NghiPhep>>> GetNghiPheps()
        {
            return await _context.NghiPheps.ToListAsync();
        }

        // GET: api/NghiPheps/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NghiPhep>> GetNghiPhep(int id)
        {
            var nghiPhep = await _context.NghiPheps.FindAsync(id);

            if (nghiPhep == null)
            {
                return NotFound();
            }

            return nghiPhep;
        }

        // PUT: api/NghiPheps/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNghiPhep(int id, NghiPhep nghiPhep)
        {
            if (id != nghiPhep.MaNghiPhep)
            {
                return BadRequest();
            }

            _context.Entry(nghiPhep).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NghiPhepExists(id))
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

        // POST: api/NghiPheps
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<NghiPhep>> PostNghiPhep(NghiPhep nghiPhep)
        {
            _context.NghiPheps.Add(nghiPhep);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNghiPhep", new { id = nghiPhep.MaNghiPhep }, nghiPhep);
        }

        // DELETE: api/NghiPheps/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNghiPhep(int id)
        {
            var nghiPhep = await _context.NghiPheps.FindAsync(id);
            if (nghiPhep == null)
            {
                return NotFound();
            }

            _context.NghiPheps.Remove(nghiPhep);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NghiPhepExists(int id)
        {
            return _context.NghiPheps.Any(e => e.MaNghiPhep == id);
        }
    }
}
