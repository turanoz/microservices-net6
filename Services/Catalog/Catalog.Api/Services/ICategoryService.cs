using Catalog.Api.Dtos;
using Shared.Dtos;

namespace Catalog.Api.Services
{
    public interface ICategoryService
    {
        Task<Response<List<CategoryDto>>> GetAllAsync();

        Task<Response<CategoryDto>> CreateAsync(CategoryDto category);

        Task<Response<CategoryDto>> GetByIdAsync(string id);
    }
}
