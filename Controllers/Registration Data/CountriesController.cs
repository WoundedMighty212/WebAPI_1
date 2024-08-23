using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI_1.Data;
using WebAPI_1.Models.RegistrationData;
namespace WebAPI_1.Controllers.Registration_Data
{
    [ApiController]
    [Route("api/[controller]")]
    public class CountriesController : Controller
    {
        private readonly ApplicationDbContext _context;
        public CountriesController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: api/Countries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Countries>>> GetCountries()
        {
            return await _context.Countries.ToListAsync();
        }

        // GET: api/Countries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Countries>> GetCountries(int id)
        {
            var Countries = await _context.Countries.FindAsync(id);

            if (Countries == null)
            {
                return NotFound();
            }

            return Countries;
        }

        // POST: api/Countries
        [HttpPost]
        public async Task<ActionResult<Countries>> PostCountries(Countries Countries)
        {
            _context.Countries.Add(Countries);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCountries), new { id = Countries.id }, Countries);
        }

        // PUT: api/Countries/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCountries(int id, Countries Countries)
        {
            if (id != Countries.id)
            {
                return BadRequest();
            }

            _context.Entry(Countries).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CountriesExists(id))
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

        // DELETE: api/Countries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCountries(int id)
        {
            var Countries = await _context.Countries.FindAsync(id);
            if (Countries == null)
            {
                return NotFound();
            }

            _context.Countries.Remove(Countries);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CountriesExists(int id)
        {
            return _context.Countries.Any(e => e.id == id);
        }
    }
}

