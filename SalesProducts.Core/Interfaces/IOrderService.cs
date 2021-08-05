using SalesProducts.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SalesProducts.Core.Interfaces
{
    
    public interface IOrderService
    {
        IEnumerable<Order> GetOrders();
        Task<Order> GetOrder(int id);
        Task InsertOrder(Order order);
        Task<bool> UpdateOrder(Order order);
        Task<bool> DeleteOrder(int id);
    }
}
