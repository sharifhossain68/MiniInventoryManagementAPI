using AutoMapper;
using MiniInventory.Application.DTOs;
using MiniInventory.Application.Interface;
using MiniInventory.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniInventory.Application.Service
{
    public class ProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;

        }
        public async Task<IEnumerable<ProductDTO>> GetAllProductsAsync()
        {
            var products = await _productRepository.GetAllProduct();
            return _mapper.Map<IEnumerable<ProductDTO>>(products);

        }
        public async Task<ProductDTO> CreateProductAsync(CreateProductDTO createProductDTO)
        {
            var product = new Product(0, createProductDTO.Name, createProductDTO.Price, createProductDTO.StockQuantity, createProductDTO.Description);
            await _productRepository.AddProduct(product);
            await _productRepository.SavSaveChanges();
           return _mapper.Map<ProductDTO>(product);
        }
        public async Task<ProductDTO?> GetByIdAsync(int id)
        {
            var p = await _productRepository.GetByIdProduct(id);
            return p == null ? null : _mapper.Map<ProductDTO>(p);
        }

        public async Task<bool> UpdateProductAsync(int id, UpdateProductDTO  updateProductDTO)
        {
        
            var product = await _productRepository.GetByIdProduct(id);
            if(product == null)
            {
                return false;
            }
            product.UpdateProduct(updateProductDTO.Name, updateProductDTO.Description, updateProductDTO.Price, updateProductDTO.StockQuantity);
            _productRepository.UpdateProduct(product); 
            _mapper.Map<ProductDTO>(product);
            await _productRepository.SavSaveChanges();
            return true; 
        }
        public async Task<bool> RemoveProductAsync(int id)
        {

            var product = await _productRepository.GetByIdProduct(id);
            if (product == null)
            {
                return false;
            }
             _productRepository.RemoveProduct(product);
            
            await _productRepository.SavSaveChanges();
            return true;
        }
    }
    
}
