using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using LetsMeetApp.Data.Models;

using static LetsMeetApp.GCommon.ValidationConstants.ApplicationUser;

namespace LetsMeetApp.Data.Configuration
{
    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> entity)
        {
            entity.Property(u => u.FirstName)
                  .IsRequired()
                  .HasMaxLength(ApplicationUserFirstNameMaxLength);

            entity.Property(u => u.LastName)
                  .IsRequired()
                  .HasMaxLength(ApplicationUserLastNameMaxLength);

            entity.Property(u => u.City)
                  .IsRequired()
                  .HasMaxLength(ApplicationUserCityMaxLength);

            entity.Property(u => u.Country)
                  .IsRequired()
                  .HasMaxLength(ApplicationUserCountryMaxLength);

            entity.Property(u => u.Bio)
                  .HasMaxLength(ApplicationUserBioMaxLength);

            entity.Property(u => u.AvatarUrl)
                  .HasMaxLength(ApplicationUserAvatarUrlMaxLength);
        }

        public static void Seed(ModelBuilder builder)
        {
            var admin = new ApplicationUser
            {
                Id = new Guid("11111111-1111-1111-1111-111111111111"),
                FirstName = "System",
                LastName = "Admin",
                UserName = "admin@letsmeet.com",
                NormalizedUserName = "ADMIN@LETSMEET.COM",
                Email = "admin@letsmeet.com",
                NormalizedEmail = "ADMIN@LETSMEET.COM",
                EmailConfirmed = true,
                City = "Sofia",
                Country = "Bulgaria",
                BirthDate = new DateTime(1990, 1, 1),
                SecurityStamp = "11111111-1111-1111-1111-111111111111",
                PasswordHash = "AQAAAAIAAYagAAAAEFSEH0Cf94mKE/j8ZHPDb7oaLF2tLT+53BFCrbqqNjzC2TlUeU7KKkLH5eFdWVbcEA=="
            };

            builder.Entity<ApplicationUser>().HasData(admin);
        }
    }
}
