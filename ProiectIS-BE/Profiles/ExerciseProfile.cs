using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProiectIS_BE.DAL.Entities;
using ProiectIS_BE.Models.Exercise;

namespace ProiectIS_BE.Profiles
{
    public class ExerciseProfile : Profile
    {
        public ExerciseProfile()
        {
            CreateMap<Exercise, ExercisePreviewModel>();
        }
    }
}
