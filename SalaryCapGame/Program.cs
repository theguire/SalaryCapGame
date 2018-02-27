using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SalaryCapServices;
using SalaryCapData;

namespace SalaryCapGame
{
    public class Program
    {
        public static void Main( string[] args )
        {
            var host = BuildWebHost( args );
            using ( var scope = host.Services.CreateScope() )
            {
                var services = scope.ServiceProvider;

                try
                {
                    var context = services.GetRequiredService<GameDBContext>();
                    DbInitializer.Initialize( context );
                    JsonService jsonService = new JsonService( context );
                    jsonService.UpdatePlayerRoster();
                    jsonService.UpdateDailyStats();
                    
                }
                catch ( Exception ex )
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError( ex, "An error occurred seeding the DB." );
                }
                host.Run();
            }
                
                
             
        }

        public static IWebHost BuildWebHost( string[] args )
        {
            return ( new WebHostBuilder()
                        .UseKestrel()
                        .UseContentRoot( Directory.GetCurrentDirectory() )
                        .UseIISIntegration()
                        .UseStartup<Startup>()
                        .UseDefaultServiceProvider( options => options.ValidateScopes = false )
                        .UseApplicationInsights()
                        .Build() );
        }
    }
}
