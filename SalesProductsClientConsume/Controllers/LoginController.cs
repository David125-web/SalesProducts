using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SalesProductsClientConsume.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SalesProductsClientConsume.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILogger<LoginController> _logger;
        private readonly IAccountService _accountService;
        private readonly IConfiguration _configuration;

        public LoginController(IAccountService accountService, IConfiguration configuration)
        {
            _accountService = accountService;
            _configuration = configuration;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
               var token = await _accountService.GetToken(_configuration["SalesPorductAccount:clientId"], _configuration["SalesPorductAccount:clientScret"]);
            }
            catch (Exception ex) 
            {
                Debug.Write(ex);
            }
            return View();
        }
        
       
     
    }

}
