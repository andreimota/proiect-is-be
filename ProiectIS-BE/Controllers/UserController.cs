using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProiectIS_BE.Api.Models;
using ProiectIS_BE.Data.Entities;
using ProiectIS_BE.Service.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProiectIS_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public UserController(IMapper mapper, IUserService userService)
        {
            _mapper = mapper;
            _userService = userService;
        }

        
        [HttpPost]
        public ActionResult<string> Register(UserModel user) 
        {
            var mappedUser = _mapper.Map<UserModel, User>(user);
            
            var jwt = _userService.RegisterUser(mappedUser);

            return Ok(jwt);
        }

    }
}
