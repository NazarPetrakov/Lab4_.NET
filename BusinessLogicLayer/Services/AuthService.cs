using BusinessLogicLayer.DTOs.Auth;
using BusinessLogicLayer.DTOs.Token;
using BusinessLogicLayer.DTOs.User;
using BusinessLogicLayer.Exeptions;
using BusinessLogicLayer.Services.Interfaces;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Identity;

namespace BusinessLogicLayer.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ITokenService _tokenService;

        public AuthService(
                UserManager<IdentityUser> userManager,
                RoleManager<IdentityRole> roleManager,
                ITokenService tokenService)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _tokenService = tokenService;
        }

        public async Task<TokenDto> Login(LoginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);
            if (user == null || !await _userManager.CheckPasswordAsync(user, loginDto.Password))
                throw new BadRequestException("Invalid Credentials");

            var userRoles = await _userManager.GetRolesAsync(user);

            var token = _tokenService.GenerateAccessToken(user.Id, userRoles);
            return new TokenDto() { AccessToken = token };
        }
        public async Task<TokenDto> RegisterUser(RegisterDto registrationDto)
        {
            var userExists = await _userManager.FindByEmailAsync(registrationDto.Email);
            if (userExists != null)
                throw new BadRequestException("Invalid Credentials");

            var user = await CreateNewUserAsync(registrationDto.Email, registrationDto.Password);

            var token = _tokenService.GenerateAccessToken(user.Id, new List<string>());

            return new TokenDto() { AccessToken = token };
        }
        public async Task ChangePassword(string userId, ChangePasswordDto changePasswordDto)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
                throw new EntityNotFoundException<User>(userId);

            if (changePasswordDto.NewPassword != changePasswordDto.ConfirmedPassword)
                throw new BadRequestException("New password and confirmed password do not match");

            var passwordValid = await _userManager.CheckPasswordAsync(user, changePasswordDto.CurrentPassword);
            if (!passwordValid)
                throw new BadRequestException("Current password is incorrect");

            var result = await _userManager.ChangePasswordAsync(user, changePasswordDto.CurrentPassword, changePasswordDto.NewPassword);
            if (!result.Succeeded)
                throw new BadRequestException("Failed to change password");
        }

        public Task Logout(string userId)
        {
            throw new NotImplementedException();
        }
        private async Task<IdentityUser> CreateNewUserAsync(string email, string password)
        {
            IdentityUser user = new()
            {
                Email = email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = email,
            };

            var result = await _userManager.CreateAsync(user, password);
            if (!result.Succeeded)
                throw new Exception("Something went wrong");

            return user;
        }

    }
}
