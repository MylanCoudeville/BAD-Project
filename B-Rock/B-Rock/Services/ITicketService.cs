using B_Rock.Data;

namespace B_Rock.Services
{
    public interface ITicketService
    {
        void AddTicket(Ticket ticket);
        IEnumerable<Ticket> GetAllFromUser(string userId);
    }
}
