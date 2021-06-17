using ERPSchoolAPI.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERPSchoolAPI
{
    public class Startup
    {
        /// <summary>
        /// for application services
        /// </summary>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddTransient<CustomMiddleWare>();
            services.AddTransient<IStudentsRepository, StudentsRepository>();
            services.TryAddTransient<IStudentsRepository, CustomStudentsRepository>();
        }

        /// <summary>
        /// for middleware and http request pipeline
        /// </summary>
        public void Configure(IApplicationBuilder app,IWebHostEnvironment env)
        {
            if(env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseRouting();
            app.UseEndpoints((endpoints) =>
            {
                endpoints.MapGet("", (context) =>
                {
                    return context.Response.WriteAsync(".Net5 Web API - Home \n");
                });
                endpoints.MapGet("/sayhi", (context) =>
                {
                    return context.Response.WriteAsync("Hi web api users \n");
                });
                endpoints.MapControllers();
            });
        }
    }
}
