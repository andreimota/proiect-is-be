using AutoMapper;
using ProiectIS_BE.DAL.Entities;
using ProiectIS_BE.Models.Quiz;

namespace ProiectIS_BE.Profiles
{
    public class QuizProfile : Profile
    {
        public QuizProfile()
        {
            CreateMap<Quiz, QuizModel>();
            CreateMap<QuizAnswer, AnswerModel>();
            CreateMap<QuizQuestion, QuestionModel>();
        }
    }
}
