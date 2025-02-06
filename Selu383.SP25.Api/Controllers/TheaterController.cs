using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Selu383.SP25.Api.Dtos;
using Selu383.SP25.Api.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Selu383.SP25.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TheatersController : ControllerBase
    {
        private readonly DataContext _context;

        public TheatersController(DataContext context)
        {
            _context = context;
        }

        // GET: api/theaters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TheaterDto>>> GetTheaters()
        {
            var theaters = await _context.Theaters
                .Select(t => new TheaterDto
                {
                    Id = t.Id,
                    Name = t.Name,
                    Address = t.Address,
                    SeatCount = t.SeatCount
                }).ToListAsync();

            return Ok(theaters);
        }

        // GET: api/theaters/1
        [HttpGet("{id}")]
        public async Task<ActionResult<TheaterDto>> GetTheater(int id)
        {
            var theater = await _context.Theaters
                .Where(t => t.Id == id)
                .Select(t => new TheaterDto
                {
                    Id = t.Id,
                    Name = t.Name,
                    Address = t.Address,
                    SeatCount = t.SeatCount
                }).FirstOrDefaultAsync();

            if (theater == null)
            {
                return NotFound();
            }

            return Ok(theater);
        }

        // POST: api/theaters
        [HttpPost]
        public async Task<ActionResult<TheaterDto>> PostTheater(TheaterDto theaterDto)
        {
            if (string.IsNullOrEmpty(theaterDto.Name) || theaterDto.Name.Length > 120)
            {
                return BadRequest("Name must be provided and cannot be longer than 120 characters.");
            }

            if (string.IsNullOrEmpty(theaterDto.Address))
            {
                return BadRequest("Address is required.");
            }

            if (theaterDto.SeatCount < 1)
            {
                return BadRequest("SeatCount must be a valid number and greater than 0.");
            }

            var theater = new Theater
            {
                Name = theaterDto.Name,
                Address = theaterDto.Address,
                SeatCount = theaterDto.SeatCount
            };

            _context.Theaters.Add(theater);
            await _context.SaveChangesAsync();

            // Return the created DTO with 201 status code
            return CreatedAtAction(nameof(GetTheater), new { id = theater.Id }, new TheaterDto
            {
                Id = theater.Id,
                Name = theater.Name,
                Address = theater.Address,
                SeatCount = theater.SeatCount
            });
        }

        // PUT: api/theaters/1
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTheater(int id, [FromBody] TheaterDto theaterDto)
        {
            // Validate the input data
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Find the theater by id
            var theater = await _context.Theaters.FindAsync(id);
            if (theater == null)
            {
                return NotFound();  // Theater not found
            }

            // Update the theater's properties
            theater.Name = theaterDto.Name;
            theater.Address = theaterDto.Address;
            theater.SeatCount = theaterDto.SeatCount; 

            // Save the changes
            await _context.SaveChangesAsync();

            // Return the updated TheaterDto
            return Ok(new TheaterDto
            {
                Id = theater.Id,
                Name = theater.Name,
                Address = theater.Address,
                SeatCount = theater.SeatCount 
            });
        }


        // DELETE: api/theaters/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTheater(int id)
        {
            var theater = await _context.Theaters.FindAsync(id);
            if (theater == null)
            {
                return NotFound();
            }

            _context.Theaters.Remove(theater);
            await _context.SaveChangesAsync();

            return NoContent(); // 204 No Content for successful deletion
        }
    }
}
