using EyAuthServer.Core.Configuration;
using EyAuthServer.Core.Dtos;
using EyAuthServer.Core.Models;

namespace EyAuthServer.Core.Services
{
    public interface ITokenService
    {
        TokenDto CreateToken(UserApp userApp);

        ClientTokenDto CreateTokenByClient(Client client);
    }
}
