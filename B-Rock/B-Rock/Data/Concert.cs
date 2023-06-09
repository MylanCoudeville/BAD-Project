using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace B_Rock.Data
{
    public class Concert
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string PerformedBy { get; set; }
        public string Location { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public DateTime DateAndTime { get; set; }
        public double Price { get; set; }
        public string UniqueURL { get; set; }
        public string ExternLink { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
