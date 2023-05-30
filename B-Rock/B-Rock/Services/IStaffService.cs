using B_Rock.Data;

namespace B_Rock.Services
{
    public interface IStaffService
    {
        public IEnumerable<Staff> GetAll();
        public Staff GetById(int id);
        public void Add(Staff staff);
        public void Update(Staff staff);
        public void Delete(Staff staff);
    }
}
