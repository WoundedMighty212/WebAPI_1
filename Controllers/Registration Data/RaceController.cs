using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI_1.Data;
using WebAPI_1.Models.RegistrationData;
namespace WebAPI_1.Controllers.Registration_Data
{
    [ApiController]
    [Route("api/[controller]")]
    public class RaceController : Controller
    {
        private readonly ApplicationDbContext _context;
        public RaceController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: api/Race
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Race>>> GetRace()
        {
            return await _context.Race.ToListAsync();
        }

        // GET: api/Race/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Race>> GetRace(int id)
        {
            var Race = await _context.Race.FindAsync(id);

            if (Race == null)
            {
                return NotFound();
            }

            return Race;
        }

        // POST: api/Race
        [HttpPost]
        public async Task<ActionResult<Race>> PostRace(Race Race)
        {
            _context.Race.Add(Race);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetRace), new { id = Race.id }, Race);
        }

        // PUT: api/Race/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRace(int id, Race Race)
        {
            if (id != Race.id)
            {
                return BadRequest();
            }

            _context.Entry(Race).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RaceExists(id))
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

        // DELETE: api/Race/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRace(int id)
        {
            var Race = await _context.Race.FindAsync(id);
            if (Race == null)
            {
                return NotFound();
            }

            _context.Race.Remove(Race);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RaceExists(int id)
        {
            return _context.Race.Any(e => e.id == id);
        }
    }

}

