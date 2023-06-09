using B_Rock.Data;
using B_Rock.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace B_Rock.Controllers
{
    [Authorize(Policy = "AdminOnly")]
    public class QuestionController : Controller
    {
        private readonly IQuestionService _questionService;
        public QuestionController(IQuestionService questionService)
        {
            _questionService = questionService;
        }
        public IActionResult Index()
        {
            IEnumerable<Question> questions = _questionService.GetAll();
            return View(questions);
        }
        [HttpPost]
        public IActionResult Index(int id)
        {
            Question q = _questionService.GetById(id);
            q.IsAnswered = true;
            _questionService.UpdateQuestion(q);
            return RedirectToAction("Index");
        }
    }
}
