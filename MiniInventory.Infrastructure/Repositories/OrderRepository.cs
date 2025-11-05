using Microsoft.EntityFrameworkCore;
using MiniInventory.Application.Interface;
using MiniInventory.Domain.Entities;
using MiniInventory.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniInventory.Infrastructure.Repositories
{
    internal class OrderRepository :IOrderRepository
    {
        private readonly MiniInventoryDbContext _context;
        public OrderRepository(MiniInventoryDbContext context)
        {
            _context = context;
        }
        public async Task CreateOrder(Order order)
        {
            await _context.Orders.AddAsync(order);
            
        }
        public async Task<Order?> GetOrderById(int id)
        {
           return await _context.Orders.FirstOrDefaultAsync(f => f.OrderId == id);

        }
        public async Task SavSaveChanges()
        {
            await _context.SaveChangesAsync();
        }

    }
}
