﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SalesProducts.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SalesProducts.Infrastructure.Filters
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception.GetType() == typeof(BusinessExceptions))
            {
                var exception = (BusinessExceptions)context.Exception;
                var validation = new
                {
                    status = 400,
                    title = "Bad Request",
                    Detail = exception.Message,
                };
                var json = new
                {
                    errors = new[] { validation }
                };
                context.Result = new BadRequestObjectResult(json);
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.ExceptionHandled = true;
            }
        }
    }
}