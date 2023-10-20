using Microsoft.Owin.Builder;
using Microsoft.Owin;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace Activ.Pointis.WebAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //OwinStartup();
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }

        /*private void OwinStartup()
        {
            var startup = new Startup();
            var app = new AppBuilder();

            startup.Configuration(app);

            //app.Build(typeof(IAppBuilder));
            //var owinPipeline = app.Build(typeof(IAppBuilder));

            // set the Owin pipeline
            //OwinContext.Set("Microsoft.Owin.Host.SystemWeb.OwinHttpListener", owinPipeline);
        }*/
    }
}
