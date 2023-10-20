using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Http.Cors;
using System.Web.Routing;
using System.Web.Http;

namespace Activ.Pointis.WebAPI.App_Start
{
    public class RouteConfig
    {
        /*public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            var cors = new EnableCorsAttribute(Utilities.Mapping.CORS_Allow, "*", "*", "DataServiceVersion, MaxDataServiceVersion");
            routes.MapRoute(
            name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { action = "Index", id = UrlParameter.Optional }
            );
        }*/
    }
}