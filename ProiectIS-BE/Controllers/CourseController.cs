using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProiectIS_BE.Models.Article;
using ProiectIS_BE.Service.Interfaces;

namespace ProiectIS_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;
        private readonly IMapper _mapper;

        public CourseController(ICourseService courseService, IMapper mapper)
        {
            _courseService = courseService;
            _mapper = mapper;
        }


        [HttpGet]
        public IActionResult GetCoursesPreview() 
        {
            var courses = _courseService.GetCourses();

            var mappedCourses = _mapper.Map<IEnumerable<CoursePreviewModel>>(courses);

            return Ok(mappedCourses);
        }

        [HttpGet("{courseId}")]
        public IActionResult GetCourse(int courseId)
        {
            var course = _courseService.GetCourse(courseId);

            var mappedCourse = _mapper.Map<CourseModel>(course);

            return Ok(mappedCourse);
        }

    }
}
