using AutoMapper;
using ProiectIS_BE.Data.Entities;
using ProiectIS_BE.Api.Models;
using ProiectIS_BE.Models;
using ProiectIS_BE.Models.User;
using ProiectIS_BE.DAL.Entities;

namespace ProiectIS_BE.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile() 
        {
            CreateMap<UserModel, User>().ReverseMap();
            CreateMap<AuthenticateModel, User>().ReverseMap();

            CreateMap<User, AuthorModel>();

            CreateMap<User, UserDashboardModel>()
                .ForMember(dest => dest.Exercises, map => map.MapFrom(src => src.UserExercises))
                .ForMember(dest => dest.Courses, map => map.MapFrom(src => src.CourseUsers));

            CreateMap<UserCourses, UserCourseModel>()
                .ForMember(dest => dest.Id, map => map.MapFrom(src => src.CourseId))
                .ForMember(dest => dest.Title, map => map.MapFrom(src => src.Course.Title))
                .ForMember(dest => dest.Technology, map => map.MapFrom(src => src.Course.Technology))
                .ForMember(dest => dest.Difficulty, map => map.MapFrom(src => src.Course.Difficulty))
                .ForMember(dest => dest.Image, map => map.MapFrom(src => src.Course.Image))
                .ForMember(dest => dest.QuizTotalPoints, map => map.MapFrom(src => src.Course.Quiz.Questions.Count));

            CreateMap<UserExercises, UserExerciseModel>()
                .ForMember(dest => dest.Id, map => map.MapFrom(src => src.ExerciseId))
                .ForMember(dest => dest.Title, map => map.MapFrom(src => src.Exercise.Title))
                .ForMember(dest => dest.Technology, map => map.MapFrom(src => src.Exercise.Technology))
                .ForMember(dest => dest.Difficulty, map => map.MapFrom(src => src.Exercise.Difficulty));
        }
    }
}
