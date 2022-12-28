using System;
using System.Threading.Tasks;

namespace Front.Services.Interfaces
{
    public interface IClientCredentialTokenService
    {
        Task<String> GetToken();
    }
}