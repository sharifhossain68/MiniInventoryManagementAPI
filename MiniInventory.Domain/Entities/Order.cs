using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniInventory.Domain.Entities
{
    public enum OrderStatus
    {
      Pending , Completed, Cancelled   
    }
    public class Order
    {
        public int OrderId { get;  set; }
        public string CustomerName { get; set; } = null!;
        public DateTime OrderDate { get;  set; }
        public decimal TotalAmount { get;  set; }
        public OrderStatus Status { get;  set; }
        public List<OrderItem> Items { get; set; } = new();
        public Order( string customerName, DateTime orderDate, decimal totalAmount, OrderStatus status) 
        { 
          CustomerName = customerName;
          OrderDate = orderDate;
          TotalAmount = totalAmount;
          Status = status;
        }
        public  class OrderItem
        {
            public int OrderItemId { get;  set; }
            public int ProductId { get;  set; }
            public int Quantity { get;  set; }
            public decimal UnitPrice { get;  set; }
      
            private OrderItem() { }

            public OrderItem(int productId, int quantity, decimal unitPrice)
            {
                if (quantity <= 0) throw new ArgumentOutOfRangeException(nameof(quantity), "Product  quantity must be grater than zero!"); ;
                ProductId = productId;
                Quantity = quantity;
                UnitPrice = unitPrice;
            }
        }
    }
}
