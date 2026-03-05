using LetsMeetApp.Data;
using LetsMeetApp.Services.Core.Contracts;
using LetsMeetApp.Web.ViewModels.Event;
using Microsoft.EntityFrameworkCore;

namespace LetsMeetApp.Services.Core
{
    public class CategoryService(LetsMeetDbContext dbContext) : ICategoryService
    {
        public async Task<IEnumerable<EventCreateCategoryDropdownModel>> GetCategoriesDropdownAsync(string userId)
        {
            var userIdGuid = Guid.Parse(userId);

            var categoriesAsDropdown = await dbContext
                .Categories
                .AsNoTracking()
                .Where(c => c.CreatorId == userIdGuid || c.CreatorId == null)
                .Select(c => new EventCreateCategoryDropdownModel()
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToArrayAsync();

            return categoriesAsDropdown;
        }
    }
}
