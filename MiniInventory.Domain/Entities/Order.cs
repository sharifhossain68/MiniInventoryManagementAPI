using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        public int Status { get;  set; }
        public List<OrderItem> Items { get; set; } = new();
        public Order(string customerName, DateTime orderDate, decimal totalAmount)
        {
            OrderId = 0;
            CustomerName = customerName;
            OrderDate = DateTime.UtcNow;
            TotalAmount = totalAmount;
            Status = 0;
        }
        public class OrderItem
        {
            [Key]
            public int OrderItemId { get; set; }
            
            public int ProductId { get; set; }
            [ForeignKey("OrderId")]
            public int OrderId { get; set; }

            public int Quantity { get; set; }
         
            private OrderItem() { }

            public OrderItem(int productid, int quantity)
            {
                if (quantity <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(quantity), "product  quantity must be grater than zero!"); ;

                }
                ProductId = productid;
                Quantity = quantity;
                
            }
        }
    }
}
