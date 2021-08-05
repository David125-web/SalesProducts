using SalesProducts.Core.Entities;
using SalesProducts.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SalesProducts.Core.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _UnitOfWork;

        public ProductService(IUnitOfWork UnitOfWork)
        {
            _UnitOfWork = UnitOfWork;
        }

        public async Task<Product> GetProduct(int id)
        {
            return await _UnitOfWork.ProductRepository.GetById(id);
        }
        public IEnumerable<Product> GetProducts()
        {
            return _UnitOfWork.ProductRepository.GetAll();
        }

        public async Task InsertProduct(Product product)
        {
            await _UnitOfWork.ProductRepository.Add(product);
            await _UnitOfWork.SaveChangesAsync();

        }

        public async Task<bool> UpdateProduct(Product product)
        {
            _UnitOfWork.ProductRepository.Update(product);
            _UnitOfWork.SaveChangesAsync();

            return true;
        }
        public async Task<bool> DeleteProduct(int id)
        {
            await _UnitOfWork.ProductRepository.Delete(id);
            return true;
        }

    }
}