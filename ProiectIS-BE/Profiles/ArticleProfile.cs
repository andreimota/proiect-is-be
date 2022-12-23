using AutoMapper;
using ProiectIS_BE.DAL.Entities;
using ProiectIS_BE.Models.Article;

namespace ProiectIS_BE.Profiles
{
    public class ArticleProfile : Profile
    {
        public ArticleProfile()
        {
            CreateMap<Article, ArticlePreviewModel>();
        }
    }
}
