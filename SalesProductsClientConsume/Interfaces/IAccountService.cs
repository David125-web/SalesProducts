using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesProductsClientConsume.Interfaces
{
    public interface IAccountService
    {
        Task<string> GetToken(string clientId, string clientScret);

    }
}
