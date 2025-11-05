using Microsoft.EntityFrameworkCore;
using MiniInventory.Application.Interface;
using MiniInventory.Domain.Entities;
using MiniInventory.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniInventory.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public readonly MiniInventoryDbContext _dbContext;
        public ProductRepository(MiniInventoryDbContext context)
        {
            _dbContext = context;
        }
        public async Task<IEnumerable<Product>> GetAllProduct()
        {
            return await _dbContext.Products.AsNoTracking().ToListAsync();

        }
        public async Task AddProduct(Product product)
        {
           await  _dbContext.Products.AddAsync(product);
        }
        public async Task<Product?> GetByIdProduct(int id)
        {
            return await _dbContext.Products.FirstOrDefaultAsync(p => p.ProductId == id);
        }
        public async Task<Product?> GetByIdForUpdate(int id)
        {
            return await _dbContext.Products.FirstOrDefaultAsync(p => p.ProductId == id);
        }
       public void UpdateProduct(Product product)
        { 
            _dbContext.Update(product);
        }
        public void RemoveProduct(Product product)
        {
            _dbContext.Remove(product);
        }
       

        public async Task SavSaveChanges()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
