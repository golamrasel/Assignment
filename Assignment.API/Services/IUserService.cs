using System.Threading.Tasks;
using AutoWrapper.Wrappers;
using Services.DTO;

namespace Services
{
    public interface IUserService
    {
        Task<ApiResponse> LoginUser(LoginDTO user);
        Task<ApiResponse> Register(RegistrationDTO user);
    }
}