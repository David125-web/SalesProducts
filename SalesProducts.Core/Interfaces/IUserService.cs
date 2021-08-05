using SalesProducts.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SalesProducts.Core.Interfaces
{
    
   public interface IUserService
    {
        IEnumerable<User> GetUsers();
        Task<User> GetUser(int id);
        Task InsertUser(User user);
        Task<bool> UpdateUser(User user);
        Task<bool> DeleteUser(int id);
    }
}
