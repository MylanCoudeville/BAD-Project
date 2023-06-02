using B_Rock.Data;

namespace B_Rock.Services
{
    public interface IConcertService
    {
        Concert GetById(int Id);
        IEnumerable<Concert> GetAll();
        IEnumerable<Concert> GetAllInFuture();
        void AddConcert(Concert concert);
        void RemoveConcert(Concert concert);
        void UpdateConcert(Concert concert);
    }
}
