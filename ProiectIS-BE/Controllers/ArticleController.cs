using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProiectIS_BE.Models.Article;
using ProiectIS_BE.Service.Interfaces;

namespace ProiectIS_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly IArticleService _articleService;
        private readonly IMapper _mapper;

        public ArticleController(IArticleService articleService, IMapper mapper)
        {
            _articleService = articleService;
            _mapper = mapper;
        }


        [HttpGet]
        public IActionResult GetArticlesPreview() 
        {
            var articles = _articleService.GetArticles();

            var mappedArticles = _mapper.Map<IEnumerable<ArticlePreviewModel>>(articles);

            return Ok(mappedArticles);
        }
    }
}
