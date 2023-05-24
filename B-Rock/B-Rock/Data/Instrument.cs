using System.ComponentModel.DataAnnotations;

namespace B_Rock.Data
{
    public class Instrument
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Fill in the name of the instrument.")]
        public string Name { get; set; }
    }
}
