using AutoMapper;
using Business.Abstract;
using Business.Concrete;
using DataAccess;
using Entities.Dtos.Request;
using Entities.Dtos.Response;
using Entities.Exceptions;
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
        private readonly IAuthService _authService;
        public UserController(IMapper mapper,IUserService userService, IAuthService authService)
        {
            _mapper = mapper;
            _userService = userService;
            _authService = authService;
        }

        [HttpGet]

        public IActionResult GetAllUsers() {
            try
            {
                var records = _mapper.Map<List<UserResponseDto>>(_userService.GetAll());
                return Ok(records);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("{id}")]
        public IActionResult GetUser(int id) {
            try
            {
                var record = _mapper.Map<UserResponseDto>(_userService.GetById(id));
                return Ok(record);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult AddUser(UserRequestDto user)
        {
            try
            {
                var userRequest = _mapper.Map<User>(user);
                User userResponse = _userService.Add(userRequest);
                UserResponseDto userResponseDto = _mapper.Map<UserResponseDto>(userResponse);
                return Ok(userResponseDto);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpPost("token")]
        public IActionResult Login(LoginRequestDto user)
        {
            try
            {
                if (_userService.CheckPassword(user.Email, user.Password))
                {
                    string token = _authService.generateToken(_userService.GetByEmail(user.Email));
                    return Ok(token);
                }
                else
                {
                    return BadRequest("False Password!");
                }
                
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            try
            {
                _userService.Delete(id);
                return Ok("User successfully deleted with id "+id+"!");
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult UpdateUser(UserUpdateRequestDto user)
        {

            try
            {
                var userRequest = _mapper.Map<User>(user);
                User userResponse = _userService.Update(userRequest);
                UserResponseDto updatedUser = _mapper.Map<UserResponseDto>(userResponse);
                return Ok(updatedUser);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
