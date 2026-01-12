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
    public class HopDongLaoDongsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public HopDongLaoDongsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/HopDongLaoDongs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HopDongLaoDong>>> GetHopDongLaoDongs()
        {
            return await _context.HopDongLaoDongs.ToListAsync();
        }

        // GET: api/HopDongLaoDongs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HopDongLaoDong>> GetHopDongLaoDong(int id)
        {
            var hopDongLaoDong = await _context.HopDongLaoDongs.FindAsync(id);

            if (hopDongLaoDong == null)
            {
                return NotFound();
            }

            return hopDongLaoDong;
        }

        // PUT: api/HopDongLaoDongs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHopDongLaoDong(int id, HopDongLaoDong hopDongLaoDong)
        {
            if (id != hopDongLaoDong.MaHopDong)
            {
                return BadRequest();
            }

            _context.Entry(hopDongLaoDong).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HopDongLaoDongExists(id))
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

        // POST: api/HopDongLaoDongs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HopDongLaoDong>> PostHopDongLaoDong(HopDongLaoDong hopDongLaoDong)
        {
            _context.HopDongLaoDongs.Add(hopDongLaoDong);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHopDongLaoDong", new { id = hopDongLaoDong.MaHopDong }, hopDongLaoDong);
        }

        // DELETE: api/HopDongLaoDongs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHopDongLaoDong(int id)
        {
            var hopDongLaoDong = await _context.HopDongLaoDongs.FindAsync(id);
            if (hopDongLaoDong == null)
            {
                return NotFound();
            }

            _context.HopDongLaoDongs.Remove(hopDongLaoDong);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HopDongLaoDongExists(int id)
        {
            return _context.HopDongLaoDongs.Any(e => e.MaHopDong == id);
        }
    }
}
