using B_Rock.Data;

namespace B_Rock.Services
{
    public interface IInstrumentService
    {
        int GetAmountInstruments();
        IEnumerable<Instrument> GetAll();
    }
}
