using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CursLib.Models;
using CursWeb;

namespace CursWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripsController : ControllerBase
    {
        private readonly Avto_VakzalContext _context;
        private int input;

        public TripsController(Avto_VakzalContext context)
        {
            _context = context;
        }

        // GET: api/Trips
        [HttpPost("ListTrips")]
        public async Task<ActionResult<IEnumerable<Trip>>> GetTrips()
        {
          if (_context.Trips == null)
          {
              return NotFound();
          }
            return await _context.Trips.Include(s => s.BusNavigation).ToListAsync();
        }

        // GET: api/Trips/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Trip>> GetTrip(int id)
        {
          if (_context.Trips == null)
          {
              return NotFound();
          }
            var trip = await _context.Trips.FindAsync(id);

            if (trip == null)
            {
                return NotFound();
            }

            return trip;
        }

        // PUT: api/Trips/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("put")]
        public async Task<IActionResult> PutTrip([FromBody] Trip trip)
        {
            input = trip.TripId;

            var origin = _context.Trips.Find(input);


            _context.Entry(trip).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TripExists(input))
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

        // POST: api/Trips
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("save")]
        public async Task<ActionResult<Trip>> PostTrip(Trip trip)
        {
          if (_context.Trips == null)
          {
              return Problem("Entity set 'Avto_VakzalContext.Trips'  is null.");
          }
            _context.Trips.Add(trip);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTrip", new { id = trip.TripId }, trip);
        }

        // DELETE: api/Trips/5
        [HttpPost("delete")]
        public async Task<IActionResult> DeleteTrip([FromBody] int id)
        {
            if (_context.Trips == null)
            {
                return NotFound();
            }
            var trip = await _context.Trips.FindAsync(id);
            if (trip == null)
            {
                return NotFound();
            }

            _context.Trips.Remove(trip);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TripExists(int id)
        {
            return (_context.Trips?.Any(e => e.TripId == id)).GetValueOrDefault();
        }
    }
}
