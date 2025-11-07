using MiniInventory.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniInventory.Application.DTOs
{
    public class OrderDTOs
    {
        public record OrderDTO(int OrderId,string CustomerName, DateTime OrderDate, decimal TotalAmount);
        public record CreateOrderDTO(int OrderId,string CustomerName, DateTime OrderDate, decimal TotalAmount);
    }
}
