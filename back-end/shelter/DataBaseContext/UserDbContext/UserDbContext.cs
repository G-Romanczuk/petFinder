using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using shelter.Models.UserModels;

namespace shelter.DataBaseContext.UserDbContext
{
    public class UserDbContext : IdentityDbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {
                
        }
        public DbSet<UserModel> Users { get; set; }
    }
}
