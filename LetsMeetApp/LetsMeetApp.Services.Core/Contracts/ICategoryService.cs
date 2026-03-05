using LetsMeetApp.Web.ViewModels.Event;

namespace LetsMeetApp.Services.Core.Contracts
{
    public interface ICategoryService
    {
        public Task<IEnumerable<EventCreateCategoryDropdownModel>> GetCategoriesDropdownAsync(string userId);
    }
}
