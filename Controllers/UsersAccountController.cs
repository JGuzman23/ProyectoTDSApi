using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MinerdDocApi.Data;
using MinerdDocApi.Models.UserAccount;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinerdDocApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersAccountController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UsersAccountController(AppDbContext context)
        {
            _context = context;
        }

      
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsuario()
        {
            return await _context.User.ToListAsync();
        }

     
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUsuarioPorId(int id)
        {
            var user = await _context.User.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

       
        [HttpPut("{id}")]
        public async Task<IActionResult> Actualizar(int id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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

        
       

    
        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var user = await _context.User.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.User.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(int id)
        {
            return _context.User.Any(e => e.Id == id);
        }
    }
}
