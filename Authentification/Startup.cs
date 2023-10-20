using Authentification.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using static System.Net.Mime.MediaTypeNames;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security.OAuth;

[assembly: OwinStartup(typeof(Authentification.Startup))]
namespace Authentification
{
    public class Startup
    {
        public static OAuthAuthorizationServerOptions AuthOP{ get; private set; }
    public void Configuration(IAppBuilder app)
        {
            ConfigureOAuth(app);
        }

        private void ConfigureOAuth(IAppBuilder app)
        {
            //  app.CreatePerOwinContext<OwinAuthDbContext>(() => new OwinAuthDbContext());
            //   app.CreatePerOwinContext<UserManager<IdentityUser>>(CreateManager);
            var p = new AuthorizationServerProvider();

            AuthOP = new OAuthAuthorizationServerOptions
            {
                TokenEndpointPath = new PathString("/oauth/token"),
                AuthorizeEndpointPath = new PathString("/api/Account/ExternalLogin"),
                // AuthorizeEndpointPath = new PathString("/token"), 
                Provider = p,//new OAuthAuthorizationServerProvider(),
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(30),
                AllowInsecureHttp = true,

            };
            app.UseOAuthAuthorizationServer(AuthOP);

            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());


        }

        private static UserManager<IdentityUser> CreateManager(IdentityFactoryOptions<UserManager<IdentityUser>> options, IOwinContext context)
        {
            var userStore = new UserStore<IdentityUser>(context.Get<OwinAuthDbContext>());
            var owinManager = new UserManager<IdentityUser>(userStore);
            return owinManager;
        }


    }
}