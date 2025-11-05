using MiniInventory.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniInventory.Application.Interface
{
    public interface IProductRepository
    {
      
        Task<IEnumerable<Product>> GetAllProduct();
        Task AddProduct(Product product);
        Task<Product?> GetByIdProduct(int id);
        Task<Product?> GetByIdForUpdate(int id);
        void UpdateProduct(Product product);
        void RemoveProduct(Product product);
   
        Task SavSaveChanges();




    }
}
