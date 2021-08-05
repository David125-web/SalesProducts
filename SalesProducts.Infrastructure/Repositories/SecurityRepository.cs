using Microsoft.EntityFrameworkCore;
using SalesProducts.Core.Entities;
using SalesProducts.Core.Interfaces;
using SalesProducts.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SalesProducts.Infrastructure.Repositories
{
    public class SecurityRepository : BaseRepository<Security>, ISecurityRepository
    {
        public SecurityRepository(SalesProductsContext contex) : base(contex) { }

        public async Task<Security> GetLoginByCredentials(UserLogin login)
        {
            return await _entities.FirstOrDefaultAsync(x => x.User == login.User && x.Password == login.Password);
        }
    }
}