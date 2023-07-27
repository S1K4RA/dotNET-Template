
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.Http.Routing;
using $safeprojectname$.Repositories;

namespace $safeprojectname$
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/octet-stream"));

            var services = new ServiceCollection();
            
            services.AddTransient<IRepository, Repository>();
            //services.AddTransient<EmployeeController>();
            //services.AddTransient<AlphaController>();

            var provider = services.BuildServiceProvider(new ServiceProviderOptions
            {
                ValidateOnBuild = true,
                ValidateScopes = true,
            });

            GlobalConfiguration.Configuration.Services.Replace(
                typeof(IHttpControllerActivator),
                new ControllerActivator(provider)
            );
        }
    }
}
