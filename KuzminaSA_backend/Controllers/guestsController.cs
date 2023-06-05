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
          if (_context.guest == null)
          {
              return NotFound();
          }
            return await _context.guest.ToListAsync();
        }

        //// GET: api/guests/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<guest>> Getguest(int id)
        //{
        //  if (_context.guest == null)
        //  {
        //      return NotFound();
        //  }
        //    var guest = await _context.guest.FindAsync(id);

        //    if (guest == null)
        //    {
        //        return NotFound();
        //    }

        //    return guest;
        //}

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
          if (_context.guest == null)
          {
              return Problem("Entity set 'hotelContext.guests'  is null.");
          }
            var guests = new guest(guest.Id, guest.last_name, guest.first_name, guest.happy_b);
            _context.guest.Add(guests);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getguests", new { id = guest.Id }, guest);
        }

        // DELETE: api/guests/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteguest(int id)
        {
            if (_context.guest == null)
            {
                return NotFound();
            }
            var guests = await _context.guest.FindAsync(id);
            if (guests == null)
            {
                return NotFound();
            }

            _context.guest.Remove(guests);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool guestExists(int id)
        {
            return (_context.guest?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        // GET: api/Guests/happ_b
        [HttpGet("{happy_b}")]
        public async Task<ActionResult<IEnumerable<guest>>> GetGuestsByBirth(string happy_b)
        {
            if (_context.guest == null)
            {
                return NotFound();
            }
            var guests = await _context.guest
                .Where(a => a.happy_b == happy_b)
                .ToListAsync();

            if (guests == null)
            {
                return NotFound();
            }

            return guests;
        }
    }
}
