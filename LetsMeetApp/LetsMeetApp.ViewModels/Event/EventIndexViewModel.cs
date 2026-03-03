namespace LetsMeetApp.Web.ViewModels.Event
{
    public class EventIndexViewModel
    {
        public IEnumerable<EventViewModel> MyEvents { get; set; }

        public IEnumerable<EventViewModel> DiscoverEvents { get; set; }

        public EventsFilterViewModel Filter { get; set; }
    }
}
