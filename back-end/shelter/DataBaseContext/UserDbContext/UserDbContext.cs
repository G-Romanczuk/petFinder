 using Microsoft.EntityFrameworkCore;
using shelter.Models.UserModels;

namespace shelter.DataBaseContext.UserDbContext
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {
                
        }
        public DbSet<UserModel> Users { get; set; }
    }
}
