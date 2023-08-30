using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using shelter.Models.ShelterModels;
using shelter.Models.UserModels;

namespace shelter.DataBaseContext.ShelterDbContext
{
    public class ShelterDbContext : DbContext
    {
        public ShelterDbContext(DbContextOptions<ShelterDbContext> options) : base (options)
        {
                
        }
        public DbSet<ShelterModel> Shelters { get; set;}
    }
}
