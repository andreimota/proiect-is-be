using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProiectIS_BE.Api.Models;
using ProiectIS_BE.Data.Entities;
using ProiectIS_BE.Models;
using ProiectIS_BE.Service.Interfaces;

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

        [HttpPost("register")]
        public ActionResult<string> Register(UserModel user) 
        {
            var mappedUser = _mapper.Map<UserModel, User>(user);
            
            var jwt = _userService.RegisterUser(mappedUser);

            return Created("", "Created successfully");
        }

        [HttpPost("login")]
        public ActionResult<string> Authenticate(AuthenticateModel user)
        {
            var mappedUser = _mapper.Map<AuthenticateModel, User>(user);

            var jwt = _userService.Authenticate(mappedUser);

            if (jwt != "") return Ok(jwt);
            else return BadRequest("Incorrect username or password.");
        }
    }
}
