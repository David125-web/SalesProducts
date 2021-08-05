using SalesProducts.Core.Entities;
using SalesProducts.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SalesProducts.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _UnitOfWork;

        public UserService(IUnitOfWork UnitOfWork)
        {
            _UnitOfWork = UnitOfWork;
        }

        public async Task<User> GetUser(int id)
        {
            return await _UnitOfWork.UserRepository.GetById(id);
        }
        public IEnumerable<User> GetUsers()
        {
            return _UnitOfWork.UserRepository.GetAll();
        }

        public async Task InsertUser(User user)
        {
            await _UnitOfWork.UserRepository.Add(user);
            await _UnitOfWork.SaveChangesAsync();

        }

        public async Task<bool> UpdateUser(User user)
        {
            _UnitOfWork.UserRepository.Update(user);
            _UnitOfWork.SaveChangesAsync();

            return true;
        }
        public async Task<bool> DeleteUser(int id)
        {
            await _UnitOfWork.UserRepository.Delete(id);
            return true;
        }

    }
}