using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace BrightSpark
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "v1/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "GetWords",
                routeTemplate: "v1/{controller}/{sort}/{unique}",
                defaults: new { sort = RouteParameter.Optional, unique = RouteParameter.Optional });

        }
    }
}
