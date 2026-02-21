using LetsMeetApp.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LetsMeetApp.Data
{
    public class LetsMeetDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public LetsMeetDbContext(DbContextOptions options)
            : base(options)
        {
        }
    }
}
