using BusinessLogicLayer.DTOs.Auth;
using BusinessLogicLayer.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services.Interfaces
{
    public interface IAuthService
    {
        Task<bool> RegisterUser(RegisterDto registrationDto);
        Task Login(LoginDto loginDto);
        Task Logout(string userId);
        Task<UserGetDto> GetUserByToken(string token);
        Task<bool> ChangePassword(long Id, ChangePasswordDto changePasswordDto);
    }
}
