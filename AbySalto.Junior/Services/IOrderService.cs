using AbySalto.Junior.DTO;
using AbySalto.Junior.Models;

namespace AbySalto.Junior.Services
{
    public interface IOrderService
    {
        Task<Order> CreateOrderAsync(OrderDto dto);
        Task<List<Order>> GetAllOrdersAsync(bool sortByTotal = false, bool desc = false);
        Task UpdateOrderStatusAsync(Guid orderId, OrderStatus newStatus);
    }
}
