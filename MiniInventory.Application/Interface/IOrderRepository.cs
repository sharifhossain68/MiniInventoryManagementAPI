using MiniInventory.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MiniInventory.Domain.Entities.Order;

namespace MiniInventory.Application.Interface
{
    public interface IOrderRepository
    {
        Task<Order>  CreateOrder(Order order);
        Task<IEnumerable<Order>> GetAllOrder();
        Task CreateOrderItems(List<OrderItem> orderItems, int orderId);
        Task ReduceProduct(List<OrderItem> orderItems);

        Task SavSaveChanges();
 
    }
     
}
