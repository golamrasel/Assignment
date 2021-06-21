using AutoWrapper.Wrappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services;
using Services.DTO;
using System;
using System.Net;
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
                try
                {
                    var result = await _userService.Register(register);
                    return new ApiResponse { Result = result, StatusCode = (int)HttpStatusCode.OK };
                }
                catch (Exception ex)
                {
                    return new ApiResponse { Result = ex.Message, StatusCode = (int)HttpStatusCode.BadRequest, IsError = true };
                }

            }

            [AllowAnonymous]
            [HttpPost("Login")]
            public async Task<ApiResponse> Login([FromBody] LoginDTO user)
            {
                try
                {
                    var result = await _userService.LoginUser(user);
                    return new ApiResponse {Result = result,  StatusCode = (int)HttpStatusCode.OK};
                }

                catch (Exception ex)
                {
                    return new ApiResponse { Result = ex.Message, StatusCode = (int)HttpStatusCode.BadRequest, IsError = true };
                }
            }
        }

    }
}

