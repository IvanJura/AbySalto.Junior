using AbySalto.Junior.Models;

namespace AbySalto.Junior.DTO
{
    public class OrderResponse
    {
        public Guid Id { get; set; }
        public string CustomerName { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime OrderTime { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public string DeliveryAddress { get; set; }
        public string ContactPhone { get; set; }
        public string Note { get; set; }
        public string Currency { get; set; }
        public decimal TotalAmount { get; set; }
        public List<OrderItemResponse> Items { get; set; }
    }
}
