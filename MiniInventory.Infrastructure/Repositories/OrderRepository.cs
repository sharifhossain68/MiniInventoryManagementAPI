using Microsoft.EntityFrameworkCore;
using MiniInventory.Application.Interface;
using MiniInventory.Domain.Entities;
using MiniInventory.Infrastructure.Data;
using System.Threading.Tasks;
using static MiniInventory.Domain.Entities.Order;

namespace MiniInventory.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly MiniInventoryDbContext _context;

        public OrderRepository(MiniInventoryDbContext context)
        {
            _context = context;
        }
        
        public async  Task<Order> CreateOrder(Order order)
        {
            // Declare OrderId variable

            try
            {
                //Add the order first
                await _context.Orders.AddAsync(order);
                 await _context.SaveChangesAsync();
                
                // Get the generated OrderId
                return order;
             
            }
            catch (Exception ex)
            {
                // Roll back transaction if something failed
               
                throw new Exception($"Error creating order: {ex.Message}");
            }

            
        }
      
        public async Task<IEnumerable<Order>> GetAllOrder()
        {
            try
            {
                return await _context.Orders
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving orders: {ex.Message}");
            }
        }
        public async Task CreateOrderItems(List<OrderItem> orderItems,int orderId)
        {

            // Assign the OrderId to each item 
            foreach (var item in orderItems)
            {
                item.OrderId = orderId;
            }

            await _context.OrderItems.AddRangeAsync(orderItems);
            await _context.SaveChangesAsync();
        }
        public async Task  ReduceProduct(List<OrderItem> orderItems)
        {
            foreach (var item in orderItems)
            {
              

                var product = await _context.Products.FirstOrDefaultAsync(p => p.ProductId == item.ProductId);
                if (product != null)
                {
                    // update product stock
                    product.StockQuantity -= item.Quantity;
                    _context.Products.Update(product);
                    _context.SaveChanges();
                }
            }
        }
        public async Task<IEnumerable<OrderItem>> GetByIdOrderItem(int orderId)
        {
            return await _context.OrderItems.Where(o => o.OrderId == orderId).ToListAsync();
        }
        public  void updateStatus(int status,int orderId)
        {
            var  data = _context.Orders.Where(o => o.OrderId == orderId).FirstOrDefault()!;

            data.Status = status;
            _context.Update(data);
            _context.SaveChangesAsync();


        }
        public async Task SaveChange()
        {
            await _context.SaveChangesAsync();
        }

      
    }
}
