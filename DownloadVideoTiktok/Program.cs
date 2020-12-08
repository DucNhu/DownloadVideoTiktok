using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace DownloadVideoTiktok
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
                    webBuilder.ConfigureKestrel((hostingContext, serverOptions) =>
                    {
                        if (hostingContext.HostingEnvironment.EnvironmentName == "Production")
                        {
                            serverOptions.Listen(IPAddress.Any, 80);
                        }
                        else
                        {
                            serverOptions.Listen(IPAddress.Any, 5111);
                            serverOptions.Listen(IPAddress.Any, 5110, listenOptions =>
                            {
                                listenOptions.UseHttps();
                            });
                        }
                    });
                });
    }
}
