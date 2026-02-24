using LetsMeetApp.Data;
using Microsoft.EntityFrameworkCore;

namespace LetsMeetApp.Web.Infrastructure.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static void ApplyMigrations(this WebApplication app, ILogger logger)
        {
            using var scope = app.Services.CreateScope();
            try
            {
                var db = scope.ServiceProvider.GetRequiredService<LetsMeetDbContext>();
                db.Database.Migrate();
                logger.LogInformation("Database migrations applied successfully.");
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error applying database migrations.");
                throw;
            }
        }
    }
}
