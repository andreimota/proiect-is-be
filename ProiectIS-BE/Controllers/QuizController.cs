using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProiectIS_BE.Models.Quiz;
using ProiectIS_BE.Service.Implementations;
using ProiectIS_BE.Service.Interfaces;

namespace ProiectIS_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IQuizService _quizService;

        public QuizController(IQuizService quizService, IMapper mapper)
        {
            _quizService = quizService;
            _mapper = mapper;
        }


        [HttpGet("{quizId}")]
        public IActionResult GetQuiz(int quizId)
        {
            var quiz = _quizService.GetQuiz(quizId);

            var mappedQuiz = _mapper.Map<QuizModel>(quiz);

            mappedQuiz.CourseId = _quizService.GetCourseIdFromQuiz(quizId);

            return Ok(mappedQuiz);
        }

        [HttpPut("{courseId}/{userId}")]
        public IActionResult UpdateUserScore(int userId, int courseId, ScoreModel model)
        {
            _quizService.UpdateUserScore(userId, courseId, model.Score);

            return Ok();
        }
    }
}
