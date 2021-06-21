using AutoWrapper.Wrappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services;
using Services.DTO;
using System.Threading.Tasks;

namespace Assignment.API.Controllers
{
    namespace Notification.API.Controllers
    {
        [Route("api/[controller]")]
        [ApiController]
        public class UserController : ControllerBase
        {
            private IUserService _userService;

            public UserController(IUserService userService)
            {
                _userService = userService;
            }

            [AllowAnonymous]
            [HttpPost("Registration")]
            public async Task<ApiResponse> Registration([FromBody] RegistrationDTO register)
            {
                //  throw new InvalidOperationException("a new exception !");
                return await _userService.Register(register);
            }

            [AllowAnonymous]
            [HttpPost("Login")]
            public async Task<ApiResponse> Login([FromBody] LoginDTO user)
            {
                return await _userService.LoginUser(user);
            }

        }
    }
}
