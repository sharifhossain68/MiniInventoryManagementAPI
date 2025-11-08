using MiniInventory.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MiniInventory.Domain.Entities.Order;

namespace MiniInventory.Application.DTOs
{
    public class OrderDTOs
    {
     
        public record OrderDTO(int OrderId,string CustomerName , DateTime OrderDate, decimal TotalAmount, int Status);
        public record CreateOrderDTO(string CustomerName, decimal TotalAmount,List<OrderItem>Items);
    }
}
