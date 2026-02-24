using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using LetsMeetApp.Data.Models;

using static LetsMeetApp.GCommon.ValidationConstants.Category;

namespace LetsMeetApp.Data.Configuration
{
    public class CategoryConfiguration
        : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> entity)
        {
            entity
                .HasKey(c => c.Id);

            entity
                .Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(CategoryNameMaxLength);

            entity
               .HasIndex(c => new { c.CreatorId, c.Name })
               .IsUnique();
        }

        public static void Seed(ModelBuilder builder)
        {
            var demoCategories = new List<Category>
{
                new Category
                {
                    Id = new Guid("11111111-1111-1111-1111-111111111111"),
                    Name = "Sports",
                    CreatorId = null
                },
                new Category
                {
                    Id = new Guid("22222222-2222-2222-2222-222222222222"),
                    Name = "Music",
                    CreatorId = null
                },
                new Category
                {
                    Id = new Guid("33333333-3333-3333-3333-333333333333"),
                    Name = "Technology",
                    CreatorId = null
                },
                new Category
                {
                    Id = new Guid("44444444-4444-4444-4444-444444444444"),
                    Name = "Travel",
                    CreatorId = null
                },
                new Category
                {
                    Id = new Guid("55555555-5555-5555-5555-555555555555"),
                    Name = "Gaming",
                    CreatorId = null
                },
                new Category
                {
                    Id = new Guid("66666666-6666-6666-6666-666666666666"),
                    Name = "Cinema",
                    CreatorId = null
                }
            };

            builder.Entity<Category>().HasData(demoCategories);
        }
    }
}
