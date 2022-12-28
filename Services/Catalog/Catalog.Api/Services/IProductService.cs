using Catalog.Api.Dtos;
using Shared.Dtos;

namespace Catalog.Api.Services
{
    public interface IProductService
    {
        Task<Response<List<ProductDto>>> GetAllAsync();

        Task<Response<ProductDto>> GetByIdAsync(string id);

        Task<Response<List<ProductDto>>> GetAllByCategoryIdAsync(string id);

        Task<Response<ProductDto>> CreateAsync(ProductCreateDto productCreateDto);

        Task<Response<NoContent>> UpdateAsync(ProductUpdateDto productUpdateDto);

        Task<Response<NoContent>> DeleteAsync(string id);
    }
}
