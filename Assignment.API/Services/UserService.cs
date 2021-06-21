using AutoWrapper.Wrappers;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Services.API.Configuration;
using Services.DTO;
using Services.models;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class UserService : IUserService
    {
        private UserManager<User> _userManager;
        private readonly JwtConfig _jwtConfig;

        public UserService(UserManager<User> userManager, IOptionsMonitor<JwtConfig> optionsMonitor)
        {
            _userManager = userManager;
            _jwtConfig = optionsMonitor.CurrentValue;
        }

        public async Task<ApiResponse> LoginUser(LoginDTO user)
        {
            var existingUser = await _userManager.FindByEmailAsync(user.Email);

            if (existingUser == null)
                return new ApiResponse { Message = Constants.NotFound };

            var isCorrect = await _userManager.CheckPasswordAsync(existingUser, user.Password);

            if (!isCorrect)
                return new ApiResponse { Message = Constants.FailedLogin };

            var jwtToken = GenerateJwtToken(existingUser);

            return new ApiResponse { Message = "", Result = jwtToken, StatusCode = (int)HttpStatusCode.OK };
        }

        public async Task<ApiResponse> Register(RegistrationDTO model)
        {
            var existingUser = await _userManager.FindByEmailAsync(model.Email);

            if (existingUser != null)
                return new ApiResponse { Message = Constants.AlreadyExists };

            var user = new User { UserName = model.Email, Email = model.Email };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                var jwtToken = GenerateJwtToken(user);
                return new ApiResponse { Message = "", Result = jwtToken, StatusCode = (int)HttpStatusCode.OK };
            }
            return new ApiResponse { Message = Constants.ServerError, StatusCode = (int)HttpStatusCode.BadRequest };
        }


        protected string GenerateJwtToken(IdentityUser user)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(_jwtConfig.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("Id", user.Id),
                    new Claim(JwtRegisteredClaimNames.Email, user.Email),
                    new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(365),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            var jwtToken = jwtTokenHandler.WriteToken(token);

            return jwtToken;
        }

    }
}
