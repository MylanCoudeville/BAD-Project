using B_Rock.Data;

namespace B_Rock.Services
{
    public class TicketService : ITicketService
    {
        private readonly ApplicationDbContext _dbContext;
        public TicketService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void AddTicket(Ticket ticket)
        {
            _dbContext.Tickets.Add(ticket);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Ticket> GetAllFromUser(string userId)
        {
            return _dbContext.Tickets.Where(t => t.UserId == userId)
                .Select(t => new Ticket()
                {
                    UserId = t.UserId,
                    Id = t.Id,
                    ConcertId = t.ConcertId,
                    FirstName = t.FirstName,
                    LastName = t.LastName,
                    Email = t.Email,
                    Street = t.Street,
                    City = t.City,
                    ZIPCode = t.ZIPCode,
                    Country = t.Country,
                    Quantity = t.Quantity,
                    TotalPrice = t.TotalPrice
                }).ToList();
        }
    }
}
