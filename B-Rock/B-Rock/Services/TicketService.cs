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
            Console.WriteLine("------------------Saved Changes----------------");
        }
    }
}
