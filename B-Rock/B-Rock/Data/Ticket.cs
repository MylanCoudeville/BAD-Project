using System.ComponentModel.DataAnnotations.Schema;

namespace B_Rock.Data
{
    public class Ticket
    {
        public int Id { get; set; }
        public string? UserId { get; set; }
        public int ConcertId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string City { get; set; }
        public string ZIPCode { get; set; }
        public string Country { get; set; }
        public int Quantity { get; set; }
        public double TotalPrice { get; set; }
    }
}
