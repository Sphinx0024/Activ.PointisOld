using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.ExceptionHandling;

namespace Activ.Pointis.WebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
          
            // Itinéraires de l'API Web
            config.MapHttpAttributeRoutes();

            var cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);

            // Configuration de la sérialisation JSON
            config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            config.Formatters.JsonFormatter.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;

            config.Routes.MapHttpRoute(
            name: "DefaultApi_2",
            routeTemplate: "api/{controller}/{action}",
            defaults: new {  }
        );

            config.Routes.MapHttpRoute(
              name: "DefaultApi_1",
              routeTemplate: "api/{controller}/{action}/{id}",
              defaults: new { id = RouteParameter.Optional }
          );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}/{name}",
                defaults: new { id = RouteParameter.Optional, name = RouteParameter.Optional}
            );
        }
    }
}
