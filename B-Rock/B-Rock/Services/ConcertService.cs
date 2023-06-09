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

        public void AddConcert(Concert concert)
        {
            _dbContext.Concerts.Add(concert);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Concert> GetAll()
        {
            return _dbContext.Concerts.Where(c => c.IsDeleted == false)
                .Select(c => new Concert()
                {
                    Id = c.Id,
                    Title = c.Title,
                    PerformedBy = c.PerformedBy,
                    Location = c.Location,
                    City = c.City,
                    Country = c.Country,
                    DateAndTime = c.DateAndTime,
                    Price = c.Price,
                    UniqueURL = c.UniqueURL,
                    ExternLink = c.ExternLink,
                    IsDeleted = c.IsDeleted
                }).ToList();
        }

        public IEnumerable<Concert> GetAllInFuture()
        {
            return _dbContext.Concerts.Where(c => c.DateAndTime.Date >= DateTime.Now && c.IsDeleted == false)
                .Select(c => new Concert()
                {
                    Id = c.Id,
                    Title = c.Title,
                    PerformedBy = c.PerformedBy,
                    Location = c.Location,
                    City = c.City,
                    Country = c.Country,
                    DateAndTime = c.DateAndTime,
                    Price = c.Price,
                    UniqueURL = c.UniqueURL,
                    ExternLink = c.ExternLink,
                    IsDeleted = c.IsDeleted
                }).ToList();
        }

        public Concert GetById(int Id)
        {
            return _dbContext.Concerts.Where(c => c.Id == Id && c.IsDeleted == false)
                .Select(c => new Concert()
                {
                    Id = c.Id,
                    Title = c.Title,
                    PerformedBy = c.PerformedBy,
                    Location = c.Location,
                    City = c.City,
                    Country = c.Country,
                    DateAndTime = c.DateAndTime,
                    Price = c.Price,
                    UniqueURL = c.UniqueURL,
                    ExternLink = c.ExternLink,
                    IsDeleted = c.IsDeleted
                }).FirstOrDefault();
        }

        public void RemoveConcert(Concert concert)
        {
            _dbContext.Concerts.Update(concert);
            _dbContext.SaveChanges();
        }

        public void UpdateConcert(Concert concert)
        {
            _dbContext.Concerts.Update(concert);
            _dbContext.SaveChanges();
        }
    }
}
