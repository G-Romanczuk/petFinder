using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using shelter.DataBaseContext.UserDbContext.Configurations;
using shelter.Models.UserModels;

namespace shelter.DataBaseContext.UserDbContext
{
    public class UserDbContext : IdentityDbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {
                
        }
        public DbSet<UserModel> Users { get; set; }
        public DbSet<UserResidenceModel> Residences { get; set; }
        public DbSet<UserHabbitsModel> Habbits { get; set; }
        public DbSet<UsersDogDetailsModel> usersDogDetails { get; set; }

       /* protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserModelConfiguration());
        }*/
    }
}
