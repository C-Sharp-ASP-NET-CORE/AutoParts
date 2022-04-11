using AutoParts.Core.Models.Order;

namespace AutoParts.Core.Contracts
{
    public interface IOrderService
    {
        Task PlaceOrder(CustomerOrder order);
    }
}
