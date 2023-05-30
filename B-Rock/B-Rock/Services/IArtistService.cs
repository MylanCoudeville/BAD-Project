using B_Rock.Data;

namespace B_Rock.Services
{
    public interface IArtistService
    {
        IEnumerable<Artist> GetByInstrument(int instrumentId);
        Artist GetById(int id);
    }
}
