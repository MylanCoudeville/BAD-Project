using B_Rock.Data;

namespace B_Rock.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly ApplicationDbContext _dbContext;
        public QuestionService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddQuestion(Question question)
        {
            _dbContext.Questions.Add(question);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Question> GetAll()
        {
            return _dbContext.Questions.Select(q => new Question()
            {
                Id = q.Id,
                Email = q.Email,
                FirstName = q.FirstName,
                IsAnswered = q.IsAnswered,
                LastName = q.LastName,
                Message = q.Message,
                UserId = q.UserId,
                Created = q.Created
            }).OrderByDescending(q => q.Id);
        }

        public Question GetById(int id)
        {
            return _dbContext.Questions.Where(q => q.Id == id)
                .Select(q => new Question()
                {
                    Id = q.Id,
                    Email = q.Email,
                    FirstName = q.FirstName,
                    IsAnswered = q.IsAnswered,
                    LastName = q.LastName,
                    Message = q.Message,
                    UserId = q.UserId,
                    Created = q.Created
                }).FirstOrDefault();
        }

        public void UpdateQuestion(Question question)
        {
            _dbContext.Questions.Update(question);
            _dbContext.SaveChanges();
        }
    }
}
