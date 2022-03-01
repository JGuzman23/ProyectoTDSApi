using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MinerdDocApi.Data;
using MinerdDocApi.Models.UserAccount;
using System.Linq;
using System.Threading.Tasks;

namespace MinerdDocApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AuthController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<User>> Login(string email, string pass)
        {
            var isValid = await _context.User.Where(e => e.Correo == email && e.Contraseña == pass).FirstOrDefaultAsync();
            if (isValid == null)
            {
                return NotFound();
            }
            return isValid;
        }

      
    }
}
