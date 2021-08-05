using SalesProducts.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SalesProducts.Core.Interfaces
{
    public interface IProductService
    {
        IEnumerable<Product> GetProducts();
        Task<Product> GetProduct(int id);
        Task InsertProduct(Product product);
        Task<bool> UpdateProduct(Product product);
        Task<bool> DeleteProduct(int id);
    }
}
