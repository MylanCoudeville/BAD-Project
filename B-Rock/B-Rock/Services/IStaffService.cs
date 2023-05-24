using B_Rock.Data;

namespace B_Rock.Services
{
    public interface IStaffService
    {
        public IEnumerable<Staff> GetAll();
    }
}
