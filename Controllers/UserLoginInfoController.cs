using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI_1.Data;
using WebAPI_1.Models;
namespace WebAPI_1.Controllers
{
    public class UserLoginInfoController : Controller
    {
        private readonly ApplicationDbContext _context;
        public UserLoginInfoController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: api/UserLoginInfo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserLoginInfo>>> GetUserLoginInfo()
        {
            return await _context.UserLoginInfo.ToListAsync();
        }

        // GET: api/UserLoginInfo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserLoginInfo>> GetUserLoginInfo(int id)
        {
            var userLoginInfo = await _context.UserLoginInfo.FindAsync(id);

            if (userLoginInfo == null)
            {
                return NotFound();
            }

            return userLoginInfo;
        }

        // POST: api/UserLoginInfo
        [HttpPost]
        public async Task<ActionResult<UserLoginInfo>> PostUserLoginInfo(UserLoginInfo UserLoginInfo)
        {
            _context.UserLoginInfo.Add(UserLoginInfo);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUserLoginInfo), new { id = UserLoginInfo.id }, UserLoginInfo);
        }

        // PUT: api/UserLoginInfo/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserLoginInfo(int id, UserLoginInfo UserLoginInfo)
        {
            if (id != UserLoginInfo.id)
            {
                return BadRequest();
            }

            _context.Entry(UserLoginInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserLoginInfoExists(id))
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

        // DELETE: api/UserLoginInfo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserLoginInfo(int id)
        {
            var UserLoginInfo = await _context.UserLoginInfo.FindAsync(id);
            if (UserLoginInfo == null)
            {
                return NotFound();
            }

            _context.UserLoginInfo.Remove(UserLoginInfo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserLoginInfoExists(int id)
        {
            return _context.UserLoginInfo.Any(e => e.id == id);
        }
    }
}
