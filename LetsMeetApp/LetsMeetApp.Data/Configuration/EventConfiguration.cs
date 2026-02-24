using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using LetsMeetApp.Data.Models;

using static LetsMeetApp.GCommon.ValidationConstants.Event;

namespace LetsMeetApp.Data.Configuration
{
    public class EventConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> entity)
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Title)
                  .IsRequired()
                  .HasMaxLength(EventTitleMaxLength);

            entity.Property(e => e.Description)
                  .IsRequired()
                  .HasMaxLength(EventDescriptionMaxLength);

            entity.Property(e => e.Location)
                  .IsRequired()
                  .HasMaxLength(EventLocationMaxLength);

            entity.Property(e => e.City)
                  .IsRequired()
                  .HasMaxLength(EventCityMaxLength);

            entity.Property(e => e.Country)
                  .IsRequired()
                  .HasMaxLength(EventCountryMaxLength);

            entity.Property(e => e.ImageUrl)
                  .HasMaxLength(EventImageUrlMaxLength);

            entity.HasOne(e => e.Creator)
                  .WithMany()
                  .HasForeignKey(e => e.CreatorId)
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.Category)
                  .WithMany(c => c.Events)
                  .HasForeignKey(e => e.CategoryId)
                  .OnDelete(DeleteBehavior.Restrict);
        }

        public static void Seed(ModelBuilder builder)
        {
            var demoEvents = new List<Event>
            {
                new Event
                {
                    Id = new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                    Title = "Music Jam Session",
                    Description = "Join us for a live music session!",
                    Date = DateTime.UtcNow.AddDays(3),
                    Location = "Downtown Club",
                    City = "Sofia",
                    Country = "Bulgaria",
                    ImageUrl = "https://images.unsplash.com/photo-1511671782779-c97d3d27a1d4?auto=format&fit=crop&w=800&q=80",
                    CreatorId = new Guid("11111111-1111-1111-1111-111111111111"),
                    CategoryId = new Guid("22222222-2222-2222-2222-222222222222")
                },
                new Event
                {
                    Id = new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"),
                    Title = "Weekend Soccer",
                    Description = "Casual football match for all skill levels",
                    Date = DateTime.UtcNow.AddDays(5),
                    Location = "City Park Stadium",
                    City = "Sofia",
                    Country = "Bulgaria",
                    ImageUrl = "https://unsplash.com/photos/white-and-blue-soccer-ball-on-green-grass-field-OgqWLzWRSaI",
                    CreatorId = new Guid("11111111-1111-1111-1111-111111111111"),
                    CategoryId = new Guid("11111111-1111-1111-1111-111111111111")
                }
            };

            builder.Entity<Event>().HasData(demoEvents);
        }
    }
}
