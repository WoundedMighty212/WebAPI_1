using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI_1.Data;
using WebAPI_1.Models.RegistrationData;

namespace WebAPI_1.Controllers.Registration_Data
{
    [ApiController]
    [Route("api/[controller]")]
    public class CitiesController : Controller
    {
        private readonly ApplicationDbContext _context;
        public CitiesController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: api/Cities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cities>>> GetCities()
        {
            return await _context.Cities.ToListAsync();
        }

        // GET: api/Cities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cities>> GetCities(int id)
        {
            var Cities = await _context.Cities.FindAsync(id);

            if (Cities == null)
            {
                return NotFound();
            }

            return Cities;
        }

        // POST: api/Cities
        [HttpPost]
        public async Task<ActionResult<Cities>> PostCities(Cities Cities)
        {
            _context.Cities.Add(Cities);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCities), new { id = Cities.id }, Cities);
        }

        // PUT: api/Cities/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCities(int id, Cities Cities)
        {
            if (id != Cities.id)
            {
                return BadRequest();
            }

            _context.Entry(Cities).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CitiesExists(id))
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

        // GET: api/cities/search/{citiesName}
        [HttpGet("search/{citiesName}")]
        public async Task<ActionResult<IEnumerable<Cities>>> GetCountriesByPartialName(string citiesName)
        {
            var cities = await _context.Cities.Where(e => e.City.Contains(citiesName)).ToListAsync();

            if (cities == null || !cities.Any())
            {
                return NotFound();
            }

            return Ok(cities);
        }

        // DELETE: api/Cities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCities(int id)
        {
            var Cities = await _context.Cities.FindAsync(id);
            if (Cities == null)
            {
                return NotFound();
            }

            _context.Cities.Remove(Cities);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CitiesExists(int id)
        {
            return _context.Cities.Any(e => e.id == id);
        }
    }
}
