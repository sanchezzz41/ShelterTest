using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Shelter.Database;
using Shelter.Web.Extensions;

namespace Shelter.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build()
                .InitializeMigrations<DatabaseContext>()
                .Initialize<DatabaseInitialize>(x => x.Create().Wait())
                .Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
