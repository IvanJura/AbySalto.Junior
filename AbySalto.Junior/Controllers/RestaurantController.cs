using AbySalto.Junior.DTO;
using AbySalto.Junior.Models;
using AbySalto.Junior.Services;
using Microsoft.AspNetCore.Mvc;

namespace AbySalto.Junior.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RestaurantController : ControllerBase
    {
        private readonly IOrderService _service;
        public RestaurantController(IOrderService service) => _service = service;

        [HttpPost]
        public async Task<ActionResult<OrderResponse>> Create([FromBody] OrderDto dto)
        {
            var entity = await _service.CreateOrderAsync(dto);
            var response = MapToResponse(entity);
            return CreatedAtAction(nameof(GetById), new { id = response.Id }, response);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderResponse>>> GetAll(
            [FromQuery] bool sortByTotal = false,
            [FromQuery] bool desc = false)
        {
            var list = await _service.GetAllOrdersAsync(sortByTotal, desc);
            var responses = list.Select(MapToResponse).ToList();
            return Ok(responses);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<OrderResponse>> GetById(Guid id)
        {
            var orders = await _service.GetAllOrdersAsync(false, false);
            var entity = orders.FirstOrDefault(o => o.Id == id);
            if (entity == null) return NotFound();
            return Ok(MapToResponse(entity));
        }

        [HttpPut("{id:guid}/status")]
        public async Task<IActionResult> UpdateStatus(Guid id, [FromBody] OrderStatus status)
        {
            await _service.UpdateOrderStatusAsync(id, status);
            return NoContent();
        }

        private static OrderResponse MapToResponse(Order entity)
        {
            return new OrderResponse
            {
                Id = entity.Id,
                CustomerName = entity.CustomerName,
                Status = entity.Status,
                OrderTime = entity.OrderTime,
                PaymentMethod = entity.PaymentMethod,
                DeliveryAddress = entity.DeliveryAddress,
                ContactPhone = entity.ContactPhone,
                Note = entity.Note,
                Currency = entity.Currency,
                TotalAmount = entity.TotalAmount,
                Items = entity.Items.Select(i => new OrderItemResponse
                {
                    Id = i.Id,
                    ItemName = i.ItemName,
                    Quantity = i.Quantity,
                    Price = i.Price
                }).ToList()
            };
        }
    }
}
