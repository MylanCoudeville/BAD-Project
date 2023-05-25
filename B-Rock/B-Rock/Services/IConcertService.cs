using B_Rock.Data;

namespace B_Rock.Services
{
    public interface IConcertService
    {
        IEnumerable<Concert> GetAll();
    }
}
