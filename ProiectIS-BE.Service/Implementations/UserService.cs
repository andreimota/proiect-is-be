using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProiectIS_BE.Common;
using ProiectIS_BE.Common.Interfaces;
using ProiectIS_BE.Data;
using ProiectIS_BE.Data.Entities;
using ProiectIS_BE.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectIS_BE.Service.Implementations
{
    public class UserService : IUserService
    {
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;
        private readonly CodeAppContext _dbContext;

        public UserService(CodeAppContext dbContext, IAuthService authService, IMapper mapper) {
            _authService = authService;
            _mapper = mapper;
            _dbContext = dbContext;
        }


        public string RegisterUser(User user)
        {
            user.Salt = _authService.GetSalt(32);
            user.Password = _authService.Encrypt(user.Password + user.Salt);
            
            _dbContext.Set<User>().Add(user);

            _dbContext.SaveChanges();

            return _authService.GenerateJwtToken(user.Id);
        }

        public string Authenticate(User user)
        {
            var existingUser = _dbContext.Users.Where(u => u.Username == user.Username).FirstOrDefault();
            
            if (existingUser != null && existingUser.Password == _authService.Encrypt(user.Password + existingUser.Salt))
            {
                return _authService.GenerateJwtToken(existingUser.Id);
            }
            else
            {
                return "";
            }
        }

        public User GetUserDashboard(int userId)
        {
            var user = _dbContext.Set<User>()
                .Include(p => p.UserExercises)
                    .ThenInclude(p => p.Exercise)
                .Include(p => p.CourseUsers)
                    .ThenInclude(p => p.Course)
                    .ThenInclude(p => p.Quiz)
                    .ThenInclude(p => p.Questions)
                .Where(user => user.Id == userId)
                .FirstOrDefault();

            if(user == null) 
            {
                throw new NullReferenceException("User was not found");
            }

            return user;
        }
    }
}
