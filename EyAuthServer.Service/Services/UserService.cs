using EyAuthServer.Core.Dtos;
using EyAuthServer.Core.Models;
using EyAuthServer.Core.Services;
using EySharedLibrary.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace EyAuthServer.Service.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<UserApp> _userManager;
        private readonly SignInManager<UserApp> _signInManager;

        public UserService(UserManager<UserApp> userManager, SignInManager<UserApp> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<Response<NoDataDto>> ChangePassword(ChangePasswordDto changePasswordDto, string userName)
        {
            UserApp user = _userManager.FindByNameAsync(userName).Result;
            bool exist = _userManager.CheckPasswordAsync(user, changePasswordDto.OldPassword).Result;

            if (exist)
            {
                IdentityResult result = _userManager.ChangePasswordAsync(user, changePasswordDto.OldPassword, changePasswordDto.NewPassword).Result;
                if (result.Succeeded)
                {

                    await _signInManager.PasswordSignInAsync(user, changePasswordDto.NewPassword, true, false);
                    return Response<NoDataDto>.Success(204);
                }
                else
                {
                    var errors = result.Errors.Select(x => x.Description).ToList();
                    return Response<NoDataDto>.Fail(new ErrorDto(errors, true), 400);
                }
            }
            else
            {
                return Response<NoDataDto>.Fail(new ErrorDto("wrong password", true), 400);
            }

        }

        public async Task<Response<UserAppDto>> CreateUserAsync(CreateUserDto createUserDto)
        {
            var user = new UserApp { Email = createUserDto.Email, UserName = createUserDto.UserName };

            var result = await _userManager.CreateAsync(user, createUserDto.Password);

            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(x => x.Description).ToList();

                return Response<UserAppDto>.Fail(new ErrorDto(errors, true), 400);
            }
            return Response<UserAppDto>.Success(ObjectMapper.Mapper.Map<UserAppDto>(user), 200);
        }

        public async Task<Response<UserAppDto>> GetUserByNameAsync(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);

            if (user == null)
            {
                return Response<UserAppDto>.Fail("UserName not found", 404, true);
            }

            return Response<UserAppDto>.Success(ObjectMapper.Mapper.Map<UserAppDto>(user), 200);
        }
    }
}
