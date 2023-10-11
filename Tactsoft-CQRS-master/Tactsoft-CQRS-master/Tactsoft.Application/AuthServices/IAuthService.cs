
using Tactsoft.Application.Models.Auth;

namespace Tactsoft.Application.AuthServices;

public interface IAuthService
{
    Task<LoginResponse> Login(LoginModel model);
    Task<RegistrationResponse> Register(RegistrationModel model);
}