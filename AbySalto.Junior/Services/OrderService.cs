using AbySalto.Junior.DTO;
using AbySalto.Junior.Infrastructure.Database;
using AbySalto.Junior.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AbySalto.Junior.Services
{
    public class OrderService : IOrderService
    {
        private readonly IApplicationDbContext _db;
        public OrderService(IApplicationDbContext db) => _db = db;

        public async Task<Order> CreateOrderAsync(OrderDto dto)
        {
            var order = new Order
            {
                CustomerName = dto.CustomerName,
                PaymentMethod = dto.PaymentMethod,
                DeliveryAddress = dto.DeliveryAddress,
                ContactPhone = dto.ContactPhone,
                Note = dto.Note,
                Currency = dto.Currency,
                Items = dto.Items.Select(i => new OrderItem
                {
                    ItemName = i.ItemName,
                    Quantity = i.Quantity,
                    Price = i.Price
                }).ToList()
            };

            _db.Orders.Add(order);
            await _db.SaveChangesAsync();

            return order;
        }

        public async Task<List<Order>> GetAllOrdersAsync(bool sortByTotal = false, bool desc = false)
        {
            var list = await _db.Orders.Include(o => o.Items).ToListAsync();

            if (sortByTotal)
            {
                list = desc ? list.OrderByDescending(o => o.TotalAmount).ToList()
                     : list.OrderBy(o => o.TotalAmount).ToList();
            }
            return list;
        }

        public async Task UpdateOrderStatusAsync(Guid orderId, OrderStatus newStatus)
        {
            var order = await _db.Orders.FindAsync(orderId);

            if (order is null) throw new KeyNotFoundException("Order not found");
            order.Status = newStatus;

            await _db.SaveChangesAsync();
        }
    }
}
