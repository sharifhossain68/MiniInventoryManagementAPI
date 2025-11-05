using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniInventory.Domain.Entities
{
    public  sealed class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Product() { }
        public Product(int productid, string name, decimal price, int stockQuantity, string? description = null)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentOutOfRangeException(nameof(name), "Product name is required!");
            }
            if (price <=0)
            {
                throw new ArgumentOutOfRangeException(nameof(price), "Product price must be grater than zero!");
            }
            if (stockQuantity <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(stockQuantity), "Product stock quantity must be grater than zero!");
            }
            Name = name;
            Price = price;
            StockQuantity = stockQuantity;
            Description = description;
            CreatedAt = DateTime.UtcNow;

        }
        public void UpdateProduct(string? name, string? description, decimal? price, int? stockQuantity)
        {
            if (!string.IsNullOrWhiteSpace(name)) Name = name;
            if (description != null) Description = description;
            if (price.HasValue)
            {
                if (price.Value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(price), "Product price must be grater than zero!");
                } 
                Price = price.Value;
            }
            if (stockQuantity.HasValue)
            {
                if (stockQuantity.Value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(stockQuantity), "Product stock quantity must be grater than zero!"); ;
                }
                StockQuantity = stockQuantity.Value;
            }
            UpdatedAt = DateTime.UtcNow;
        }



    }
}

    
