using System.Threading.Tasks;
using Front.Models.Discounts;

namespace Front.Services.Interfaces
{
    public interface IDiscountService
    {
        Task<DiscountViewModel> GetDiscount(string discountCode);
    }
}