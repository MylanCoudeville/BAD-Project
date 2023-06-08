using System.ComponentModel.DataAnnotations;

namespace B_Rock.Models.Reservation
{
    public class OverviewViewModel
    {
        public int Id { get; set; }
        public string ConcertName { get; set; }
        public DateTime ConcertDateAndTime { get; set; }
        public string ConcertLocation { get; set; }
        public int Quantity { get; set; }
        public double TotalPrice { get; set; }
    }
}
