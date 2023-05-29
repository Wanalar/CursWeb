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
    public class InformationController : ControllerBase
    {
        private readonly Avto_VakzalContext _context;
        private int input;

        public InformationController(Avto_VakzalContext context)
        {
            _context = context;
        }

        // GET: api/Information
        [HttpPost("ListInformations")]
        public async Task<ActionResult<IEnumerable<Information>>> GetInformations()
        {
          if (_context.Informations == null)
          {
              return NotFound();
          }
            return await _context.Informations.ToListAsync();
        }

        // GET: api/Information/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Information>> GetInformation(int id)
        {
          if (_context.Informations == null)
          {
              return NotFound();
          }
            var information = await _context.Informations.FindAsync(id);

            if (information == null)
            {
                return NotFound();
            }

            return information;
        }

        // PUT: api/Information/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("{id}")]
        public async Task<IActionResult> PutInformation([FromBody] Information information)
        {
            input = information.InformationId;

            var origin = _context.Buses.Find(input);

            _context.Entry(origin).CurrentValues.SetValues(information);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InformationExists(input))
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

        // POST: api/Information
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("save")]
        public async Task<ActionResult<Information>> PostInformation(Information information)
        {
          if (_context.Informations == null)
          {
              return Problem("Entity set 'Avto_VakzalContext.Informations'  is null.");
          }
            _context.Informations.Add(information);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInformation", new { id = information.InformationId }, information);
        }

        // DELETE: api/Information/5
        [HttpPost("delete")]
        public async Task<IActionResult> DeleteInformation([FromBody] int id)
        {
            if (_context.Informations == null)
            {
                return NotFound();
            }
            var information = await _context.Informations.FindAsync(id);
            if (information == null)
            {
                return NotFound();
            }

            _context.Informations.Remove(information);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InformationExists(int id)
        {
            return (_context.Informations?.Any(e => e.InformationId == id)).GetValueOrDefault();
        }
    }
}
