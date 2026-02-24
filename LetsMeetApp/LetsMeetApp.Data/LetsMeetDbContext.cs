using LetsMeetApp.Data.Configuration;
using LetsMeetApp.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace LetsMeetApp.Data
{
    public class LetsMeetDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public LetsMeetDbContext(DbContextOptions<LetsMeetDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Event> Events { get; set; } = null!;

        public virtual DbSet<Category> Categories { get; set; } = null!;

        public virtual DbSet<EventParticipation> EventParticipations { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            ApplicationUserConfiguration.Seed(builder);
            CategoryConfiguration.Seed(builder);
            EventConfiguration.Seed(builder);
            EventParticipationConfiguration.Seed(builder);
        }
    }
}
