using SalesProducts.Core.Entities;
using SalesProducts.Core.Exceptions;
using SalesProducts.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SalesProducts.Core.Services
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _UnitOfWork;

        public OrderService(IUnitOfWork UnitOfWork)
        {
            _UnitOfWork = UnitOfWork;
        }

        public async Task<Order> GetOrder(int id)
        {
            return await _UnitOfWork.OrderRepository.GetById(id);
        }
        public  IEnumerable<Order> GetOrders()
        {
            return  _UnitOfWork.OrderRepository.GetAll();
        }
       
        public async Task InsertOrder(Order order)
        {
            var user = await _UnitOfWork.UserRepository.GetById(order.PedUsu);
            var product = await _UnitOfWork.ProductRepository.GetById(order.PedProd);

            if (user == null)
            {
                throw new BusinessExceptions("User doesn't exist");
            }
            if (product == null) 
            {
                throw new BusinessExceptions("Product doesn't exist");
            }
           
            await _UnitOfWork.OrderRepository.Add(order);
            await _UnitOfWork.SaveChangesAsync();

        }

        public async Task<bool> UpdateOrder(Order order)
        {
            _UnitOfWork.OrderRepository.Update(order);
            _UnitOfWork.SaveChangesAsync();

            return true;
        }
        public async Task<bool> DeleteOrder(int id)
        {
            await _UnitOfWork.OrderRepository.Delete(id);
            return true;
        }

    }
}