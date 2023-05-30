using B_Rock.Data;

namespace B_Rock.Services
{
    public class ConcertService : IConcertService
    {
        private readonly ApplicationDbContext _dbContext;
        public ConcertService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<Concert> GetAll()
        {
            return _dbContext.Concerts.Select(c => new Concert()
            {
                Id = c.Id,
                Title = c.Title,
                PerformedBy = c.PerformedBy,
                Location = c.Location,
                City = c.City,
                Country = c.Country,
                DateAndTime = c.DateAndTime,
                UniqueURL = c.UniqueURL,
                ExternLink = c.ExternLink
            }).ToList();
        }

        public Concert GetById(int Id)
        {
            return _dbContext.Concerts.Where(c => c.Id == Id).Select(c => new Concert()
            {
                Id = c.Id,
                Title = c.Title,
                PerformedBy = c.PerformedBy,
                Location = c.Location,
                City = c.City,
                Country = c.Country,
                DateAndTime = c.DateAndTime,
                UniqueURL = c.UniqueURL,
                ExternLink = c.ExternLink
            }).FirstOrDefault();
        }
    }
}
