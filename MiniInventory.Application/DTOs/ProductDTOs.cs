using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniInventory.Application.DTOs
{
    public record ProductDTO(int ProductId, string? Name , string? Description, decimal Price, int StockQuantity, DateTime CreatedAt, DateTime? UpdatedAt);
   
    public record CreateProductDTO(int ProductId, string Name, string? Description, decimal Price, int StockQuantity);
    public record UpdateProductDTO(string? Name, string? Description, decimal? Price, int? StockQuantity);
}
