using System.ComponentModel.DataAnnotations;

namespace B_Rock.Data
{
    public class Instrument
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
