using System.ComponentModel.DataAnnotations;

namespace LetsMeetApp.Web.ViewModels.Event
{
    public class EventDeleteInputModel
    {
        [Required]
        public Guid Id { get; set; }
    }
}
