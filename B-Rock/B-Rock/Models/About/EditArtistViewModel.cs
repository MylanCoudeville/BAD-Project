using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using B_Rock.Data;

namespace B_Rock.Models.About
{
    public class EditArtistViewModel
    {
        public int Id { get; set; }
        [Display(Name = "First name")]
        [Required(ErrorMessage = "Please, fill in the first name of the artist.")]
        public string FirstName { get; set; }
        [Display(Name = "Last name")]
        [Required(ErrorMessage = "Please, fill in the last name of the artist.")]
        public string LastName { get; set; }
        public string? Role { get; set; }
        [Display(Name = "Instrument")]
        [Required(ErrorMessage = "Please select an instrument the artist plays.")]
        public int InstrumentId { get; set; }
        [Required(ErrorMessage = "Please, upload an image of the new artist.")]
        public IFormFile? Image { get; set; }
        public string UniqueURL { get; set; }
        public IEnumerable<Instrument> Instruments { get; set; } = new List<Instrument>();
    }
}
