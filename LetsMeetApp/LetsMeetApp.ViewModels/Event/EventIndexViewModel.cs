namespace LetsMeetApp.Web.ViewModels.Event
{
    public class EventIndexViewModel
    {
        public IEnumerable<EventViewModel> MyEvents { get; set; } = null!;

        public IEnumerable<EventViewModel> DiscoverEvents { get; set; } = null!;

        public EventsFilterViewModel Filter { get; set; } = null!;
    }
}
