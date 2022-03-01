using Microsoft.EntityFrameworkCore;
using MinerdDocApi.Models.UserAccount;

namespace MinerdDocApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext( DbContextOptions options) : base(options)
        {

        }


        public DbSet<User> User { get; set; }
    }
}
