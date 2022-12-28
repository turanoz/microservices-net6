using System.Threading.Tasks;
using Front.Models.PhotoStocks;
using Microsoft.AspNetCore.Http;

namespace Front.Services.Interfaces
{
    public interface IPhotoStockService
    {
        Task<PhotoViewModel> UploadPhoto(IFormFile photo);

        Task<bool> DeletePhoto(string photoUrl);
    }
}