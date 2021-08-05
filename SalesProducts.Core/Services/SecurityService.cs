using SalesProducts.Core.Entities;
using SalesProducts.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SalesProducts.Core.Services
{
    public class SecurityService : ISecurityService
    {
        private readonly IUnitOfWork _UnitOfWork;

        public SecurityService(IUnitOfWork UnitOfWork)
        {
            _UnitOfWork = UnitOfWork;
        }

        public async Task<Security> GetLoginByCredentials(UserLogin login)
        {
            return await _UnitOfWork.SecurityRepository.GetLoginByCredentials(login);
        }

        public async Task RegisterUser(Security security)
        {
            await _UnitOfWork.SecurityRepository.Add(security);
            await _UnitOfWork.SaveChangesAsync();
        }
    }
}
