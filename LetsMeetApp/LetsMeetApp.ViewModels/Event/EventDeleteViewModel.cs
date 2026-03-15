using System.ComponentModel.DataAnnotations;

using static LetsMeetApp.GCommon.ValidationConstants.Event;

namespace LetsMeetApp.Web.ViewModels.Event
{
    public class EventDeleteViewModel
    {
        public Guid Id { get; set; }

        public string Title { get; set; } = null!;

        public string Creator { get; set; } = null!;

        public Guid CreatorId { get; set; }

        public int Participants { get; set; }
    }
}
