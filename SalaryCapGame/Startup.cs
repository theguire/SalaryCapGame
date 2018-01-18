using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SalaryCapData;
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

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices( IServiceCollection services )
        {
            services.AddMvc();
            services.AddSingleton( Configuration );
            services.AddScoped<IFranchise, FranchiseService>();
            services.AddScoped<IOwner, OwnerService>();
            services.AddScoped<ILeague, LeagueService>();

            services.AddDbContext<GameDBContext>( options => options
                                                    .UseSqlServer( Configuration.GetConnectionString( "LibraryConnection" )));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure( IApplicationBuilder app, IHostingEnvironment env )
        {
            if ( env.IsDevelopment() )
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler( "/Home/Error" );
            }

            app.UseStaticFiles();

            app.UseMvc( routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}" );
            });
        }
    }
}
