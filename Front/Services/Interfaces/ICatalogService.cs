using System.Collections.Generic;
using System.Threading.Tasks;
using Front.Models.Catalogs;

namespace Front.Services.Interfaces
{
    public interface ICatalogService
    {
        Task<List<ProductViewModel>> GetAllProductAsync();

        Task<List<CategoryViewModel>> GetAllCategoryAsync();

        Task<List<ProductViewModel>> GetAllProductByUserIdAsync(string userId);

        Task<ProductViewModel> GetByProductId(string productId);

        Task<bool> CreateProductAsync(ProductCreateInput productCreateInput);

        Task<bool> UpdateProductAsync(ProductUpdateInput productUpdateInput);

        Task<bool> DeleteProductAsync(string productId);
    }
}