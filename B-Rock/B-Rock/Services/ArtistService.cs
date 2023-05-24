using B_Rock.Data;
using Microsoft.EntityFrameworkCore;

namespace B_Rock.Services
{
    public class ArtistService : IArtistService
    {
        private readonly ApplicationDbContext _dbContext;
        public ArtistService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<Artist> GetByInstrument(int instrumentId)
        {
            return _dbContext.Artists.Include(a => a.Instrument)
                .Where(a => a.InstrumentId == instrumentId)
                .Select(a => new Artist
                {
                    Id = a.Id,
                    FirstName = a.FirstName,
                    LastName = a.LastName,
                    Role = a.Role,
                    InstrumentId = a.InstrumentId,
                    Instrument = a.Instrument,
                    UniqueURL= a.UniqueURL
                }).ToList();
        }
    }
}
