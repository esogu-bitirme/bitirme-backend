using AutoMapper;
using Business.Abstract;
using Business.Concrete;
using DataAccess;
using Entities.Dtos.Request;
using Entities.Dtos.Response;
using Entities.Modals;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        public UserController(IMapper mapper)
        {
            _mapper = mapper;
            _userService = new UserService();
            
        }

        [HttpGet("{id}")]
        public UserResponseDto GetUser(int id) {
            var record = _mapper.Map<UserResponseDto >(_userService.GetById(id));
            return record;
        }

        [HttpPost]
        public UserResponseDto AddUser(UserRequestDto user)
        {
            var userRequest = _mapper.Map<User>(user);
            User userResponse = _userService.Add(userRequest);
            return _mapper.Map<UserResponseDto>(userResponse);
        }

        [HttpDelete("{id}")]
        public bool DeleteUser(int id)
        {
            return _userService.Delete(id);
        }

        [HttpPut]
        public UserResponseDto UpdateUser(UserUpdateRequestDto user)
        {
            var userRequest = _mapper.Map<User>(user);
            User userResponse = _userService.Update(userRequest);
            return _mapper.Map<UserResponseDto>(userResponse);
        }

    }
}
