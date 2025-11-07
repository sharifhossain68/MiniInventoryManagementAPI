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
    public class OrderRepository :IOrderRepository
    {
        private readonly MiniInventoryDbContext _context;
        public OrderRepository(MiniInventoryDbContext context)
        {
            _context = context;
        }
        public async Task<int> CreateOrder(Order order)
        {
            var i = 0;
            try
            { 
              await   _context.Orders.AddAsync(order);
            }
            catch(Exception  ex )
            {
               throw new Exception( ex.Message);
            }
           
            return i;
         
            
        }
        public async Task<IEnumerable<Order>?> GetOrderByCustomerName(string customerName)
        {
            try
            {
                return await _context.Orders.AsNoTracking().ToListAsync();
            }
     
              catch(Exception  ex )
            {
                throw new Exception(ex.Message);
            }
            //return await _context.Orders.FirstOrDefaultAsync(f => f.OrderId == id);


        }
        public async Task SavSaveChanges()
        {
            await _context.SaveChangesAsync();
        }

    }
}
