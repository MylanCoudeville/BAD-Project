using B_Rock.Data;

namespace B_Rock.Services
{
    public interface IQuestionService
    {
        void AddQuestion(Question question);
        void UpdateQuestion(Question question);
        IEnumerable<Question> GetAll();
        Question GetById(int id);
    }
}
