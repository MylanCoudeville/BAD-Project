using System.ComponentModel.DataAnnotations;

namespace B_Rock.Models.Calendar
{
    public class DetailConcertViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        [Display(Name = "Performed by")]
        public string PerformedBy { get; set; }
        public string Location { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        [Display(Name = "Date and time")]
        public DateTime DateAndTime { get; set; }
        public string UniqueURL { get; set; }
        [Display(Name = "Extern link")]
        public string ExternLink { get; set; }
    }
}
