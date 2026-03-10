using System.ComponentModel.DataAnnotations;

using static LetsMeetApp.GCommon.ValidationConstants.Event;

namespace LetsMeetApp.Web.ViewModels.Event
{
    public class EventDeleteInputModel
    {
        public Guid Id { get; set; }

        [Required]
        [MinLength(EventTitleMinLength)]
        [MaxLength(EventTitleMaxLength)]
        public string Title { get; set; } = null!;

        [Required]
        public string Creator { get; set; } = null!;

        [Required]
        public Guid CreatorId { get; set; }

        [Required]
        public int Participants { get; set; }
    }
}
