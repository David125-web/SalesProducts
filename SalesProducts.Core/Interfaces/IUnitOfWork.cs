using SalesProducts.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SalesProducts.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<User> UserRepository { get; }
        IRepository<Product> ProductRepository { get; }

        IRepository<Order> OrderRepository { get; }

        ISecurityRepository SecurityRepository { get; }
        void SaveChanges();
        Task SaveChangesAsync();
    }
}
