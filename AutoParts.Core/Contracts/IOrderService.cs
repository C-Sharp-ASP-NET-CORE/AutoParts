using AutoParts.Core.Models;

namespace AutoParts.Core.Contracts
{
    public interface IOrderService
    {
        Task PlaceOrder(CustomerOrder order);
    }
}
