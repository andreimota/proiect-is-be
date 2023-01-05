using AutoMapper;
using ProiectIS_BE.DAL.Entities;
using ProiectIS_BE.Models.Article;

namespace ProiectIS_BE.Profiles
{
    public class CourseProfile : Profile
    {
        public CourseProfile()
        {
            CreateMap<Course, CourseModel>();
            CreateMap<Course, CoursePreviewModel>();

            CreateMap<Article, ArticleModel>();

            CreateMap<Paragraph, ParagraphModel>();
        }
    }
}
