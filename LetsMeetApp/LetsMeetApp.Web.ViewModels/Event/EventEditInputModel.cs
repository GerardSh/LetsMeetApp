using System.ComponentModel.DataAnnotations;

using static LetsMeetApp.GCommon.ValidationConstants.Event;

namespace LetsMeetApp.Web.ViewModels.Event
{
    public class EventEditInputModel
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        [MinLength(EventTitleMinLength)]
        [MaxLength(EventTitleMaxLength)]
        public string Title { get; set; } = null!;

        [Required]
        [MinLength(EventDescriptionMinLength)]
        [MaxLength(EventDescriptionMaxLength)]
        public string Description { get; set; } = null!;

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }

        [Required]
        [MinLength(EventLocationMinLength)]
        [MaxLength(EventLocationMaxLength)]
        public string Location { get; set; } = null!;

        [Required]
        [MinLength(EventCityMinLength)]
        [MaxLength(EventCityMaxLength)]
        public string City { get; set; } = null!;

        [Required]
        [MinLength(EventCountryMinLength)]
        [MaxLength(EventCountryMaxLength)]
        public string Country { get; set; } = null!;

        [MaxLength(EventImageUrlMaxLength)]
        public string? ImageUrl { get; set; }

        [Required]
        public Guid CategoryId { get; set; }

        public IEnumerable<EventCreateCategoryDropdownModel>? Categories { get; set; }
    }
}
