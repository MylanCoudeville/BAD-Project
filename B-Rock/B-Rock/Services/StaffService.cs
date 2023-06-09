using B_Rock.Data;

namespace B_Rock.Services
{
    public class StaffService : IStaffService
    {
        private readonly ApplicationDbContext _dbContext;
        public StaffService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Staff staff)
        {
            _dbContext.Staff.Add(staff);
            _dbContext.SaveChanges();
        }

        public void Delete(Staff staff)
        {
            _dbContext.Staff.Update(staff);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Staff> GetAll()
        {
            return _dbContext.Staff.Where(s => s.IsDeleted == false)
                .Select(s => new Staff
                {
                    Id = s.Id,
                    FirstName = s.FirstName,
                    LastName = s.LastName,
                    Role = s.Role,
                    Email = s.Email,
                    PhoneNumber = s.PhoneNumber,
                    UniqueURL = s.UniqueURL
                }).ToList();
        }

        public Staff GetById(int id)
        {
            return _dbContext.Staff.Where(s => s.Id == id && s.IsDeleted == false).FirstOrDefault();
        }

        public void Update(Staff staff)
        {
            _dbContext.Update(staff);
            _dbContext.SaveChanges();
        }
    }
}
