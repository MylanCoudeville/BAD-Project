using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace B_Rock.Data
{
    public class Artist
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Role { get; set; }
        [ForeignKey("Instrument")]
        public int InstrumentId { get; set; }
        public Instrument? Instrument { get; set; }
        [NotMapped]
        public IFormFile? Image { get; set; }
        public string? UniqueURL { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
