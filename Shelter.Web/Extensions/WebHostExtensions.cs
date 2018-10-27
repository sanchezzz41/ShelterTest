using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Shelter.Web.Extensions
{
    public static class WebHostExtensions
    {
        public static IWebHost InitializeMigrations<T>(this IWebHost webHost) where T:DbContext
        {
            var scope = webHost.Services.CreateScope()
                .ServiceProvider.GetService<T>();
            scope?.Database.Migrate();
            return webHost;
        }

        public static IWebHost Initialize<T>(this IWebHost webHost,
            Action<T> start)
        {
            var scope = webHost.Services.CreateScope()
                .ServiceProvider.GetService<T>();
            if (scope != null)
                start(scope);
            return webHost;
        }
    }
}
