using System.Threading.Tasks;
using Front.Models;

namespace Front.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserViewModel> GetUser();
    }
}