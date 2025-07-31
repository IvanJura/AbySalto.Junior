using System.Collections.Generic;
using AbySalto.Junior.Models;

namespace AbySalto.Junior.DTO
{
    public class OrderItemDto
    {
        public string ItemName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }

    public class OrderDto
    {
        public string CustomerName { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public string DeliveryAddress { get; set; }
        public string ContactPhone { get; set; }
        public string Note { get; set; }
        public string Currency { get; set; }
        public List<OrderItemDto> Items { get; set; }
    }

}
