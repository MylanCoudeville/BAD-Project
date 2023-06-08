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
        [Required(ErrorMessage = "Fill in your first name.")]
        public string FirstName { get; set; }
        [Display(Name = "Last name")]
        [Required(ErrorMessage = "Fill in your last name.")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Fill in your street name.")]
        public string Street { get; set; }
        [Required(ErrorMessage = "Fill in your house number.")]
        public string Number { get; set; }
        [Required(ErrorMessage = "Fill in your country.")]
        public string Country { get; set; }
        [Required(ErrorMessage = "Fill in your city name.")]
        public string City { get; set; }
        [Display(Name = "ZIP-code")]
        [Required(ErrorMessage = "Fill in your ZIP-code.")]
        public string ZIPCode { get; set; }
        public string? UserId { get; set; }
    }
}
