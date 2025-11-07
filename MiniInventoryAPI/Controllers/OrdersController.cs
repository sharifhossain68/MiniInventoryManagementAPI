using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiniInventory.Application.Service;
using MiniInventory.Domain.Entities;
using static MiniInventory.Application.DTOs.OrderDTOs;

namespace MiniInventoryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly OrderService _orderService;

        public OrdersController(OrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(CreateOrderDTO  createOrderDTO)
        {
            var createOrder = await _orderService.CreateOrderAsync(createOrderDTO);
            return CreatedAtAction(nameof(Get), new { id = createOrder.OrderId }, createOrder);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(string customerName)
        {
            var orderDTO = await _orderService.GetOrderByCustomerAsync(customerName);
            return orderDTO == null ? NotFound() : Ok(orderDTO);
        }
    }
}
