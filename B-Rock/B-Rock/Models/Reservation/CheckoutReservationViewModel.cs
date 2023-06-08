using System.ComponentModel.DataAnnotations;

namespace B_Rock.Models.Reservation
{
    public class CheckoutReservationViewModel
    {
        public int ConcertId { get; set; }
        public string Title { get; set; }
        public string Location { get; set; }
        [Display(Name = "Date and time")]
        public DateTime DateAndTime { get; set; }
        [Display(Name = "Total price")]
        public int Quantity { get; set; }
        public double TotalPrice { get; set; }
        [Display(Name = "First name")]
        public string FirstName { get; set; }
        [Display(Name = "Last name")]
        public string LastName { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        [Display(Name = "ZIP-code")]
        public string ZIPCode { get; set; }
    }
}
