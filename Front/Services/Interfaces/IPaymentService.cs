using System.Threading.Tasks;
using Front.Models.FakePayments;

namespace Front.Services.Interfaces
{
    public interface IPaymentService
    {
        Task<bool> ReceivePayment(PaymentInfoInput paymentInfoInput);
    }
}