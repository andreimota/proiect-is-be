using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProiectIS_BE.Models.Exercise;
using ProiectIS_BE.Service.Interfaces;

namespace ProiectIS_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExerciseController : ControllerBase
    {
        private readonly IExerciseService _exerciseService;
        private readonly IMapper _mapper;

        public ExerciseController(IExerciseService exerciseService, IMapper mapper)
        {
            _exerciseService = exerciseService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetExercises()
        {
            var exercises = _exerciseService.GetExercises();

            var mappedExercises = _mapper.Map<List<ExercisePreviewModel>>(exercises);

            return Ok(mappedExercises);
        }

        [HttpGet("{exerciseId}")]
        public IActionResult GetExercise(int exerciseId)
        {
            var exercise = _exerciseService.GetExercise(exerciseId);

            var mappedExercise = _mapper.Map<ExercisePreviewModel>(exercise);

            return Ok(mappedExercise);
        }

        [HttpPost("{exerciseId}/{userId}")]
        public async Task<IActionResult> TestExercise(int exerciseId, int userId, ExerciseModel model)
        {
            return Ok(await _exerciseService.TestExercise(userId, exerciseId, model.Code));
        }
    }
}
