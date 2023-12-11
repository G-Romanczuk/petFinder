using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using shelter.Models.PetModels;
using shelter.Models.ShelterModels;
using shelter.Models.UserModels;

namespace shelter.DataBaseContext.ShelterPetFinderDbContext
{
    public class ShelterPetFinderDbContext : IdentityDbContext<IdentityUser>
    {
        public ShelterPetFinderDbContext(DbContextOptions<ShelterPetFinderDbContext> options) :base(options)
        {
                
        }
        public DbSet<PetModel> Pets { get; set; }
        public DbSet<PetImg> PetImgs { get; set; }
        public DbSet<ShelterModel> Shelters { get; set; }
        public DbSet<ShelterResidenceModel> ShelterQuestionsResidence { get; set; }
        public DbSet<ShelterHabbitsModel> ShelterQuestionsHabbits { get; set; }
        public DbSet<ShelterPetDetailsModel> ShelterQuestionsPetDetails { get; set; }
        public DbSet<UserModel> UsersRegistered { get; set; }
        public DbSet<UserResidenceModel> UserQuestionsResidence { get; set; }
        public DbSet<UserHabbitsModel> UserQuestionsHabbits { get; set; }
        public DbSet<UsersDogDetailsModel> UserQuestionsPetDetails { get; set; }
    }
}
