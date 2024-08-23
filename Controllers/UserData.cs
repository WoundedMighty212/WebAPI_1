using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI_1.Data;
using WebAPI_1.Models;
namespace WebAPI_1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserDataController : Controller
    {
        private readonly ApplicationDbContext _context;
        public UserDataController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/UserData
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserData>>> GetUserData()
        {
            return await _context.UserData.ToListAsync();
        }

        // GET: api/UserData/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserData>> GetUserData(int id)
        {
            var product = await _context.UserData.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        // POST: api/UserData
        [HttpPost]
        public async Task<ActionResult<UserData>> PostUserData(UserData userData)
        {
            _context.UserData.Add(userData);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUserData), new { id = userData.id, FKID = userData.FKID}, userData);
        }

        // PUT: api/UserData/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserData(int id, UserData userData)
        {
            if (id != userData.id)
            {
                return BadRequest();
            }

            _context.Entry(userData).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserDataExists(id))
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

        // DELETE: api/UserData/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserData(int id)
        {
            var userData = await _context.UserData.FindAsync(id);
            if (userData == null)
            {
                return NotFound();
            }

            _context.UserData.Remove(userData);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserDataExists(int id)
        {
            return _context.UserData.Any(e => e.id == id);
        }
    }
}
