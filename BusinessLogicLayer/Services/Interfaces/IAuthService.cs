using BusinessLogicLayer.DTOs.Auth;
using BusinessLogicLayer.DTOs.User;
using BusinessLogicLayer.DTOs.Token;
namespace BusinessLogicLayer.Services.Interfaces
{
    public interface IAuthService
    {
        Task<TokenDto> RegisterUser(RegisterDto registrationDto);
        Task<TokenDto> Login(LoginDto loginDto);
        Task Logout(string userId);
        Task ChangePassword(string userId, ChangePasswordDto changePasswordDto);
    }
}
