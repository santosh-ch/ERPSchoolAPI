using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System;

namespace ERPSchoolAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateHostBuilder().Build().Run();
        }

        public static IHostBuilder CreateHostBuilder()
        {
           return Host.CreateDefaultBuilder().ConfigureWebHostDefaults((builder) =>
            {
                builder.UseStartup<Startup>();
            });
        }
    }
}
