namespace AbySalto.Junior.DTO
{
    public class OrderItemResponse
    {
        public Guid Id { get; set; }
        public string ItemName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
