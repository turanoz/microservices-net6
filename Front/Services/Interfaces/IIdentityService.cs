using System.Threading.Tasks;
using Front.Models;
using IdentityModel.Client;
using Shared.Dtos;

namespace Front.Services.Interfaces
{
    public interface IIdentityService
    {
        Task<Response<bool>> SignIn(SigninInput signinInput);

        Task<TokenResponse> GetAccessTokenByRefreshToken();

        Task RevokeRefreshToken();
    }
}