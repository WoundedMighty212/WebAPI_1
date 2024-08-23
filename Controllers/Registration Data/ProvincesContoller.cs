using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI_1.Data;
using WebAPI_1.Models.RegistrationData;

namespace WebAPI_1.Controllers.Registration_Data
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProvincesContoller : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        private readonly ApplicationDbContext _context;
        public ProvincesContoller(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: api/Provinces
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Provinces>>> GetProvinces()
        {
            return await _context.Provinces.ToListAsync();
        }

        // GET: api/Provinces/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Provinces>> GetProvinces(int id)
        {
            var Provinces = await _context.Provinces.FindAsync(id);

            if (Provinces == null)
            {
                return NotFound();
            }

            return Provinces;
        }

        // POST: api/Provinces
        [HttpPost]
        public async Task<ActionResult<Provinces>> PostProvinces(Provinces Provinces)
        {
            _context.Provinces.Add(Provinces);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProvinces), new { id = Provinces.id }, Provinces);
        }

        // PUT: api/Provinces/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProvinces(int id, Provinces Provinces)
        {
            if (id != Provinces.id)
            {
                return BadRequest();
            }

            _context.Entry(Provinces).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProvincesExists(id))
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

        // DELETE: api/Provinces/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProvinces(int id)
        {
            var Provinces = await _context.Provinces.FindAsync(id);
            if (Provinces == null)
            {
                return NotFound();
            }

            _context.Provinces.Remove(Provinces);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProvincesExists(int id)
        {
            return _context.Provinces.Any(e => e.id == id);
        }
    }
}
