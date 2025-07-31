using System;
using System.Collections.Generic;

namespace AbySalto.Junior.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public string CustomerName { get; set; }
        public OrderStatus Status { get; set; } = OrderStatus.Pending;
        public DateTime OrderTime { get; set; } = DateTime.UtcNow;
        public PaymentMethod PaymentMethod { get; set; }
        public string DeliveryAddress { get; set; }
        public string ContactPhone { get; set; }
        public string Note { get; set; }
        public string Currency { get; set; }
        
        public List<OrderItem> Items { get; set; } = new();

        
        public decimal TotalAmount => Items.Sum(i => i.Price * i.Quantity);
    }
}
