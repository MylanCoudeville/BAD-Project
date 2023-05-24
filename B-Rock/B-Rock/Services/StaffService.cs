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

        public IEnumerable<Staff> GetAll()
        {
            return _dbContext.Staff.Select(s => new Staff
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
    }
}
