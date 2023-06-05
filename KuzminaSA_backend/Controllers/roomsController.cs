using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KuzminaSA_backend.Models;
using static System.Reflection.Metadata.BlobBuilder;

namespace KuzminaSA_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class roomsController : ControllerBase
    {
        private readonly hotelContext _context;

        public roomsController(hotelContext context)
        {
            _context = context;
        }

        // GET: api/rooms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<room>>> Getrooms()
        {
          if (_context.room == null)
          {
              return NotFound();
          }
            return await _context.room.ToListAsync();
        }

        //// GET: api/rooms/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<room>> Getroom(int id)
        //{
        //  if (_context.room == null)
        //  {
        //      return NotFound();
        //  }
        //    var room = await _context.room.FindAsync(id);

        //    if (room == null)
        //    {
        //        return NotFound();
        //    }

        //    return room;
        //}

        // PUT: api/rooms/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putroom(int id, room room)
        {
            if (id != room.Id)
            {
                return BadRequest();
            }

            _context.Entry(room).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!roomExists(id))
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

        // POST: api/rooms
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<room>> Postroom(room room)
        {
          if (_context.room == null)
          {
              return Problem("Entity set 'hotelContext.rooms'  is null.");
          }
            var rooms = new room(room.Id, room.capacity, room.desc, room.guest, room.price);
            _context.room.Add(rooms);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getroom", new { id = room.Id }, room);
        }

        // DELETE: api/rooms/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteroom(int id)
        {
            if (_context.room == null)
            {
                return NotFound();
            }
            var room = await _context.room.FindAsync(id);
            if (room == null)
            {
                return NotFound();
            }

            _context.room.Remove(room);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool roomExists(int id)
        {
            return (_context.room?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        // GET: api/Rooms/Price
        [HttpGet("{price}")]
        public async Task<ActionResult<IEnumerable<room>>> GetRoomsByPrice(int price)
        {
            if (_context.room == null)
            {
                return NotFound();
            }
            var room = await _context.room
                .Where(b => b.price == price)
                .ToListAsync();

            if (room == null)
            {
                return NotFound();
            }

            return room;
        }
    }
}
