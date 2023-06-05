using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KuzminaSA_backend.Models;

namespace KuzminaSA_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class hotelsController : ControllerBase
    {
        private readonly hotelContext _context;

        public hotelsController(hotelContext context)
        {
            _context = context;
        }

        // GET: api/hotels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<hotel>>> Gethotel()
        {
          if (_context.hotel == null)
          {
              return NotFound();
          }
            return await _context.hotel.ToListAsync();
        }

        // GET: api/hotels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<hotel>> Gethotel(int id)
        {
          if (_context.hotel == null)
          {
              return NotFound();
          }
            var hotel = await _context.hotel.FindAsync(id);

            if (hotel == null)
            {
                return NotFound();
            }

            return hotel;
        }

        // PUT: api/hotels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Puthotel(int id, hotel hotel)
        {
            if (id != hotel.id)
            {
                return BadRequest();
            }

            _context.Entry(hotel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!hotelExists(id))
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

        // POST: api/hotels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<hotel>> Posthotel(hotel hotel)
        {
          if (_context.hotel == null)
          {
              return Problem("Entity set 'hotelContext.hotel'  is null.");
          }
            _context.hotel.Add(hotel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Gethotel", new { id = hotel.id }, hotel);
        }

        // DELETE: api/hotels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletehotel(int id)
        {
            if (_context.hotel == null)
            {
                return NotFound();
            }
            var hotel = await _context.hotel.FindAsync(id);
            if (hotel == null)
            {
                return NotFound();
            }

            _context.hotel.Remove(hotel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool hotelExists(int id)
        {
            return (_context.hotel?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
