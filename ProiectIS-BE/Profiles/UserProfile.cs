﻿using AutoMapper;
using ProiectIS_BE.Data.Entities;
using ProiectIS_BE.Api.Models;

namespace ProiectIS_BE.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile() 
        {
            CreateMap<UserModel, User>().ReverseMap();
        }
    }
}