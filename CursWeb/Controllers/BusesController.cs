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
    public class BusesController : ControllerBase
    {
        private readonly Avto_VakzalContext _context;
        private int input;

        public BusesController(Avto_VakzalContext context)
        {
            _context = context;
        }

        // GET: api/buses
        [HttpPost("ListBuses")]
        public async Task<ActionResult<IEnumerable<Bus>>> GetBuses()
        {
          if (_context.Buses == null)
          {
              return NotFound();
          }
            return await _context.Buses.ToListAsync();
        }

        // GET: api/buses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Bus>> GetBus(int id)
        {
          if (_context.Buses == null)
          {
              return NotFound();
          }
            var bus = await _context.Buses.FindAsync(id);

            if (bus == null)
            {
                return NotFound();
            }

            return bus;
        }

        // PUT: api/buses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("put")]
        public async Task<IActionResult> PutBus([FromBody] Bus bus)
        {
            input = bus.BusId;

            var origin = _context.Buses.Find(input);

            _context.Entry(origin).CurrentValues.SetValues(bus);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BusExists(input))
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

        // POST: api/buses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("save")]
        public async Task<ActionResult<Bus>> PostBus(Bus bus)
        {
          if (_context.Buses == null)
          {
              return Problem("Entity set 'Avto_VakzalContext.Buses'  is null.");
          }
            _context.Buses.Add(bus);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getbus", new { id = bus.BusId }, bus);
        }

        // DELETE: api/buses/5
        [HttpPost("delete")]
        public async Task<IActionResult> DeleteBus([FromBody] int id)
        {
            if (_context.Buses == null)
            {
                return NotFound();
            }
            var bus = await _context.Buses.FindAsync(id);
            if (bus == null)
            {
                return NotFound();
            }

            _context.Buses.Remove(bus);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BusExists(int id)
        {
            return (_context.Buses?.Any(e => e.BusId == id)).GetValueOrDefault();
        }
    }
}
