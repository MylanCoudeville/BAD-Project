using B_Rock.Data;

namespace B_Rock.Services
{
    public class InstrumentService : IInstrumentService
    {
        private readonly ApplicationDbContext _dbContext;
        public InstrumentService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Instrument> GetAll()
        {
            return _dbContext.Instruments.Select(i => new Instrument
            {
                Id = i.Id,
                Name = i.Name
            });
        }

        public int GetAmountInstruments()
        {
            return _dbContext.Instruments.Max(i => i.Id);
        }
    }
}
