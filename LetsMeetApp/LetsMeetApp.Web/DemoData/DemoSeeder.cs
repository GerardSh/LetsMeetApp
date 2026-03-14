using LetsMeetApp.Data;
using LetsMeetApp.Data.Models;
using Microsoft.AspNetCore.Identity;

namespace LetsMeetApp.Web.DemoData
{
    public static class DemoSeeder
    {
        public static async Task SeedDemoData(IServiceProvider services)
        {
            using var scope = services.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<LetsMeetDbContext>();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            var adminId = new Guid("11111111-1111-1111-1111-111111111111");
            var adminUser = await userManager.FindByIdAsync(adminId.ToString());

            if (adminUser != null) return;

            adminUser = new ApplicationUser
            {
                Id = adminId,
                FirstName = "System",
                LastName = "Admin",
                UserName = "admin@letsmeet.com",
                Email = "admin@letsmeet.com",
                EmailConfirmed = true,
                City = "Sofia",
                Country = "Bulgaria",
                BirthDate = new DateTime(1990, 1, 1)
            };

            await userManager.CreateAsync(adminUser, "Admin123!");

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

            await db.Categories.AddRangeAsync(demoCategories);
            await db.SaveChangesAsync();

            var events = new List<Event>
            {
                new Event
                {
                    Id = new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                    Title = "Music Jam Session",
                    Description = "Join us for a live music session!",
                    Date = DateTime.Today.AddDays(8).AddHours(20).AddMinutes(30),
                    Location = "Downtown Club",
                    City = "Sofia",
                    Country = "Bulgaria",
                    ImageUrl = "https://images.unsplash.com/photo-1511671782779-c97d3d27a1d4",
                    CreatorId = new Guid("11111111-1111-1111-1111-111111111111"),
                    CategoryId = new Guid("22222222-2222-2222-2222-222222222222")
                },
                new Event
                {
                    Id = new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"),
                    Title = "Weekend Soccer",
                    Description = "Casual football match for all skill levels",
                    Date = DateTime.Today.AddDays(10).AddHours(13),
                    Location = "City Park Stadium",
                    City = "Sofia",
                    Country = "Bulgaria",
                    ImageUrl = "https://images.unsplash.com/photo-1486286701208-1d58e9338013",
                    CreatorId = new Guid("11111111-1111-1111-1111-111111111111"),
                    CategoryId = new Guid("11111111-1111-1111-1111-111111111111")
                }
            };

            await db.Events.AddRangeAsync(events);
            await db.SaveChangesAsync();

            var participations = new List<EventParticipation>
            {
                new()
                {
                    Id = new Guid("aaaaaaaa-1111-aaaa-1111-aaaaaaaaaaaa"),
                    EventId = events[0].Id,
                    UserId = adminId,
                    JoinedAt = DateTime.UtcNow
                },
                new()
                {
                    Id = new Guid("bbbbbbbb-2222-bbbb-2222-bbbbbbbbbbbb"),
                    EventId = events[1].Id,
                    UserId = adminId,
                    JoinedAt = DateTime.UtcNow
                }
            };

            await db.EventParticipations.AddRangeAsync(participations);
            await db.SaveChangesAsync();
        }
    }
}
