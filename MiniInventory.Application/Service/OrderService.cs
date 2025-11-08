using AutoMapper;
using MiniInventory.Application.DTOs;
using MiniInventory.Application.Interface;
using MiniInventory.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MiniInventory.Application.DTOs.OrderDTOs;
using static MiniInventory.Domain.Entities.Order;

namespace MiniInventory.Application.Service
{
    public class OrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        public OrderService(IOrderRepository orderRepository,IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;

        }
        public async Task<IEnumerable<Order>> GetAllOrderAsync()
        {
            return await _orderRepository.GetAllOrder();
            //return  _mapper.Map<OrderDTO>(order);

        }
        public async Task<int> CreateOrderAsync(CreateOrderDTO createOrderDTO)
        {
            var order = new Order(createOrderDTO.CustomerName, createOrderDTO.TotalAmount);
            var ord =  await _orderRepository.CreateOrder(order);


            await _orderRepository.CreateOrderItems(createOrderDTO.Items, ord.OrderId);
            await _orderRepository.ReduceProduct(createOrderDTO.Items);
             return ord.OrderId;
            //return _mapper.Map<CreateOrderDTO>(order);
        }
      
    }
}
