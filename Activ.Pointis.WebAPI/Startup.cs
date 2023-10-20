using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Http;
using Microsoft.Owin.Security.DataHandler.Encoder;
using Microsoft.IdentityModel.Tokens;

using Microsoft.Owin.Security.Jwt;
using Microsoft.Owin.Security;
using Microsoft.Owin;

[assembly: OwinStartup(typeof(Activ.Pointis.WebAPI.Startup))]
namespace Activ.Pointis.WebAPI
{
    public class Startup
    {

        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();

            // configure JWT authentication
            app.UseJwtBearerAuthentication(
                new JwtBearerAuthenticationOptions
                {
                    AuthenticationMode = AuthenticationMode.Active,
                    TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Activ.Pointis.WebAPI")),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    }
                });

            //GlobalConfiguration.Configure(WebApiConfig.Register);

            // ...
        }

        /*public void Configuration(IAppBuilder app)
        {
            // Configure Web API for self-host. 
            HttpConfiguration config = new HttpConfiguration();

            // Enable authentication using JWT bearer token.
            var issuer = "http://localhost:5000"; // Set the issuer of the token.
            var audience = "http://localhost:5000"; // Set the audience of the token.
            var secret = TextEncodings.Base64Url.Decode("Activ.Pointis.WebAPI"); // Set the secret key for the token.
            var key = new SymmetricSecurityKey(secret);
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = key,
                ValidateIssuer = true,
                ValidIssuer = issuer,
                ValidateAudience = true,
                ValidAudience = audience,
                ClockSkew = TimeSpan.Zero
            };
            app.UseJwtBearerAuthentication(new JwtBearerAuthenticationOptions
            {
                AuthenticationMode = AuthenticationMode.Active,
                TokenValidationParameters = tokenValidationParameters
            });

            // ...
        }*/
    }

    
}