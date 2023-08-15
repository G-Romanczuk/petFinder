using Microsoft.EntityFrameworkCore;
using shelter.Models.PetModels;
using shelter.Models.ShelterModels;

namespace shelter.DataBaseContext.PetDbContext
{
    public class PetDbContext : DbContext
    {
        public PetDbContext(DbContextOptions<PetDbContext> options) : base(options)
        {

        }
        public DbSet<PetModel> Pets { get; set; }
    }
}
