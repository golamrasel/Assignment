using System.Threading.Tasks;
using AutoWrapper.Wrappers;
using Microsoft.AspNetCore.Mvc;
using Services.DTO;

namespace Services
{
    public interface IUserService
    {
        Task<string> LoginUser(LoginDTO user);
        Task<string> Register(RegistrationDTO user);
    }
}