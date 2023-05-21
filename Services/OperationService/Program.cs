using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace OperationService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    webBuilder.UseKestrel()
                        .ConfigureKestrel(options =>
                        {
                            options.ListenAnyIP(5008);
                        });
                });
    }
}
