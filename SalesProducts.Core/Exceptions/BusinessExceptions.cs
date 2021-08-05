using System;
using System.Collections.Generic;
using System.Text;

namespace SalesProducts.Core.Exceptions
{
    public class BusinessExceptions : Exception
    {
        public BusinessExceptions() { }

        public BusinessExceptions(string mensaje) : base(mensaje)
        {
        }
    }
}