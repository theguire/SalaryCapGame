﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace SalaryCapGame
{
    public class Program
    {
        public static void Main( string[] args )
        {
            BuildWebHost( args ).Run();
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
