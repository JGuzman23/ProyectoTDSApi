using Microsoft.AspNetCore.Mvc;
using MinerdDocApi.Data;
using MinerdDocApi.Models.UserAccount;
using System.Threading.Tasks;

namespace MinerdDocApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {

        private readonly AppDbContext _context;

        public RegisterController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<User>> Register(User user)
        {
            _context.User.Add(user);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
