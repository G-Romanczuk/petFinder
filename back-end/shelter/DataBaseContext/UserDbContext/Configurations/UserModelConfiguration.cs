using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using shelter.Models.UserModels;

namespace shelter.DataBaseContext.UserDbContext.Configurations
{
    public class UserModelConfiguration : IEntityTypeConfiguration<UserModel>
    {
        public void Configure(EntityTypeBuilder<UserModel> builder)
        {
            builder.HasMany(u => u.UserResidence)
            .WithOne(ur => ur.UserModel)
            .HasForeignKey(ur => ur.UserModelId)
            .OnDelete(DeleteBehavior.Cascade);
        }
    }

}
