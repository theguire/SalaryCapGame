using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SalaryCapData;
using SalaryCapData.Interfaces;
using SalaryCapServices;

namespace SalaryCapGame
{
    public class Startup
    {
        public Startup( IHostingEnvironment env )
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath( env.ContentRootPath )
                .AddJsonFile( "appsettings.json", optional: false, reloadOnChange: true )
                .AddJsonFile( $"appsettings.{env.EnvironmentName}.json", optional: true )
                .AddEnvironmentVariables(); // could add connection strings here.
            // here it is.q
            Configuration = builder.Build();
        }

        //public Startup( IConfiguration configuration )
        //{
        //    Configuration = configuration;
        //}

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices( IServiceCollection services )
        {
            services.AddMvc();
            services.AddSingleton( Configuration );
            //services.AddScoped<IFranchise, FranchiseService>();
            // services.AddScoped<IOwner, OwnerService>();
            //services.AddScoped<ILeague, LeagueService>();

            services.AddScoped<IFranchise, FranchiseService>();
            services.AddScoped<IOwner, OwnerService>();
            services.AddScoped<ILeague, LeagueService>();
            services.AddScoped<ITeam, TeamService>();
            services.AddScoped<IPlayer, PlayerService>();
            

            services.AddDbContext<GameDBContext>( options => options
                                                    .UseSqlServer( Configuration.GetConnectionString( "LibraryConnection" ) ) );
        }

       
        public void Configure( IApplicationBuilder app, IHostingEnvironment env )
        {
            if ( env.IsDevelopment() )
            {
                TelemetryConfiguration.Active.DisableTelemetry = true;
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler( "/Home/Error" );
            }
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseMvc( routes =>
            {

              
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Owners}/{action=OwnersList}" );
                routes.MapRoute( "Franchise", "{controller=Franchises}/{action=Edit}/{id?}" );
                routes.MapRoute( "", "{controller=Owners}/{action=List}/{id}" );
            } );
           

        }
    }
}
