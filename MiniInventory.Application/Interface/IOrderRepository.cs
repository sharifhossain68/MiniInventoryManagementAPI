using MiniInventory.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniInventory.Application.Interface
{
    public interface IOrderRepository
    {
        Task<int> CreateOrder(Order order);
        Task<IEnumerable<Order>?> GetOrderByCustomerName(string customerName);
        Task SavSaveChanges();
    }
     
}
