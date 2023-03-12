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
    public class guestsController : ControllerBase
    {
        private readonly hotelContext _context;

        public guestsController(hotelContext context)
        {
            _context = context;
        }

        // GET: api/guests
        [HttpGet]
        public async Task<ActionResult<IEnumerable<guest>>> Getguests()
        {
          if (_context.guests == null)
          {
              return NotFound();
          }
            return await _context.guests.ToListAsync();
        }

        // GET: api/guests/5
        [HttpGet("{id}")]
        public async Task<ActionResult<guest>> Getguest(int id)
        {
          if (_context.guests == null)
          {
              return NotFound();
          }
            var guest = await _context.guests.FindAsync(id);

            if (guest == null)
            {
                return NotFound();
            }

            return guest;
        }

        // PUT: api/guests/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putguest(int id, guest guest)
        {
            if (id != guest.Id)
            {
                return BadRequest();
            }

            _context.Entry(guest).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!guestExists(id))
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

        // POST: api/guests
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<guest>> Postguest(guest guest)
        {
          if (_context.guests == null)
          {
              return Problem("Entity set 'hotelContext.guests'  is null.");
          }
            _context.guests.Add(guest);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getguest", new { id = guest.Id }, guest);
        }

        // DELETE: api/guests/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteguest(int id)
        {
            if (_context.guests == null)
            {
                return NotFound();
            }
            var guest = await _context.guests.FindAsync(id);
            if (guest == null)
            {
                return NotFound();
            }

            _context.guests.Remove(guest);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool guestExists(int id)
        {
            return (_context.guests?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
