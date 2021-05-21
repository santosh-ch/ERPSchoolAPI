using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERPSchoolAPI
{
    public class CustomMiddleWare : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await context.Response.WriteAsync("Cutom MW - CustomMiddleWare.cs \n");
            await next(context);
            await context.Response.WriteAsync("Custom MW -- CustomMiddleWare.cs in return flow \n");
        }
    }
}
