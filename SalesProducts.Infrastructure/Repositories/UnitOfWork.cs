using SalesProducts.Core.Entities;
using SalesProducts.Core.Interfaces;
using SalesProducts.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SalesProducts.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SalesProductsContext _context;
        //private readonly IRepository<Post> _IPostRepository;
        private readonly IRepository<User> _UserRepository;
        private readonly IRepository<Product> _ProductRepository;
        private readonly IRepository<Order> _OrderRepository;
        private readonly ISecurityRepository _securityRepository;

        public UnitOfWork(SalesProductsContext context)
        {
            _context = context;
        }
        public IRepository<User> UserRepository => _UserRepository ?? new BaseRepository<User>(_context);

        public IRepository<Product> ProductRepository => _ProductRepository ?? new BaseRepository<Product>(_context);

        public IRepository<Order> OrderRepository => _OrderRepository ?? new BaseRepository<Order>(_context);
        public ISecurityRepository SecurityRepository => _securityRepository ?? new SecurityRepository(_context);

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            _context.SaveChangesAsync();
        }
    }
}
