using EyAuthServer.Core.Dtos;
using EySharedLibrary.Dtos;

namespace EyAuthServer.Core.Services
{
    public interface IUserService
    {
        Task<Response<UserAppDto>> CreateUserAsync(CreateUserDto createUserDto);

        Task<Response<UserAppDto>> GetUserByNameAsync(string userName);

        Task<Response<NoDataDto>> ChangePassword(ChangePasswordDto model, string userName);

    }
}
