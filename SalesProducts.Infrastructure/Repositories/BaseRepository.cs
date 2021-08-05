using Microsoft.EntityFrameworkCore;
using SalesProducts.Core.Entities;
using SalesProducts.Core.Interfaces;
using SalesProducts.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesProducts.Infrastructure.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly SalesProductsContext _context;
        protected DbSet<T> _entities;

        public BaseRepository(SalesProductsContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return _entities.AsEnumerable();
        }
       
        public async Task<T> GetById(int id)
        {
            return await _entities.FindAsync(id);
        }
        public async Task Add(T Entity)
        {
            await _entities.AddAsync(Entity);
        }
        public void Update(T Entity)
        {
            _entities.Update(Entity);
        }
        public async Task Delete(int id)
        {
            T Entity = await GetById(id);
            _entities.Remove(Entity);
        }


    }
}