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
        public async Task<CreateOrderDTO> CreateOrderAsync(CreateOrderDTO createOrderDTO)
        {
            var order = new  Order(createOrderDTO.CustomerName, createOrderDTO.OrderDate, createOrderDTO.TotalAmount, createOrderDTO.Status);
            await _orderRepository.CreateOrder(order);
            await _orderRepository.SavSaveChanges();
            return _mapper.Map<CreateOrderDTO>(order);
        }
        public async Task<CreateOrderDTO?> GetOrderByIdAsync(int id)
        {
            var order = await _orderRepository.GetOrderById(id);
            return order == null ? null : _mapper.Map<CreateOrderDTO>(order);

        }
    }
}
