﻿using System;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Routing;
using Microsoft.Framework.DependencyInjection;

namespace Agora.Api
{
    public class Startup
    {
        public void Configure(IBuilder app)
        {
            app.UseServices(services =>
            {
                services.AddMvc();
            });

            app.Use(async (context, next) =>
            {
                try
                {
                    await next();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute( 
                    "api_route",
                    "",
                    defaults: new
                    {
                        controller = "Example"
                    });
            });
        }
    }
}