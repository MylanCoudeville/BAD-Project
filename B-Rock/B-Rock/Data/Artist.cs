using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace B_Rock.Data
{
    public class Artist
    {
        [Key]
        public int Id { get; set; }
        [Display(Name ="First name")]
        [Required(ErrorMessage ="Please, fill in the first name of the artist.")]
        public string FirstName { get; set; }
        [Display(Name ="Last name")]
        [Required(ErrorMessage = "Please, fill in the last name of the artist.")]
        public string LastName { get; set; }
        public string? Role { get; set; }
        public int InstrumentId { get; set; }
        public Instrument? Instrument { get; set; }
        [NotMapped]
        public IFormFile? Image { get; set; }
        public string? UniqueURL { get; set; }
    }
    public enum ArtistRole { 
        None,
        Principal, 
        SharedPrincipal, 
        MemberOfArtisticBoard
    }
}
