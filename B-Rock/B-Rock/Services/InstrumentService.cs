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

        public int GetAmountInstruments()
        {
            return _dbContext.Instruments.Max(i => i.Id);
        }
    }
}
