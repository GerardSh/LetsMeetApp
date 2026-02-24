using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using LetsMeetApp.Data.Models;

namespace LetsMeetApp.Data.Configuration
{
    public class EventParticipationConfiguration : IEntityTypeConfiguration<EventParticipation>
    {
        public void Configure(EntityTypeBuilder<EventParticipation> entity)
        {
            entity.HasKey(p => p.Id);

            entity.HasOne(p => p.Event)
                  .WithMany(e => e.Participants)
                  .HasForeignKey(p => p.EventId)
                  .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(p => p.User)
                  .WithMany(u => u.JoinedEvents)
                  .HasForeignKey(p => p.UserId)
                  .OnDelete(DeleteBehavior.Cascade);

            entity.HasIndex(p => new { p.EventId, p.UserId })
                  .IsUnique();
        }

        public static void Seed(ModelBuilder builder)
        {
            var participations = new List<EventParticipation>
            {
                new EventParticipation
                {
                    Id = new Guid("aaaaaaaa-1111-aaaa-1111-aaaaaaaaaaaa"),
                    EventId = new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                    UserId = new Guid("11111111-1111-1111-1111-111111111111"),
                },
                new EventParticipation
                {
                    Id = new Guid("bbbbbbbb-2222-bbbb-2222-bbbbbbbbbbbb"),
                    EventId = new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"),
                    UserId = new Guid("11111111-1111-1111-1111-111111111111"),
                }
            };

            builder.Entity<EventParticipation>().HasData(participations);
        }
    }
}
