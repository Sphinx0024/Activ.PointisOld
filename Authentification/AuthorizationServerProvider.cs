using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic; 
using Microsoft.Owin.Security; 
using System.Security.Claims; 
using System.Threading.Tasks; 

namespace Authentification
{
    public class AuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        //public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        //{
        //    string clientId;
        //    string clientSecret;
        //    context.Validated();

        //    //if (context.TryGetBasicCredentials(out clientId, out clientSecret))
        //    //{
        //    //    // validate the client Id and secret against database or from configuration file.  
        //    //    context.Validated();
        //    //}
        //    //else
        //    //{
        //    //    context.SetError("invalid_client", "Client credentials could not be retrieved from the Authorization header");
        //    //    context.Rejected();
        //    //}
        //}

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            UserManager<IdentityUser> userManager =  context.OwinContext.GetUserManager<UserManager<IdentityUser>>();
            IdentityUser user;
            try
            {
                user = new IdentityUser()
                {
                    LockoutEnabled = false,
                    EmailConfirmed = false,
                    Email = "nndjd@kf.com",
                    AccessFailedCount = 0,
                    Id = "10", 
                   
                }; //await userManager.FindAsync(context.UserName, context.Password);
            }
            catch
            {
                // Could not retrieve the user due to error.  
                context.SetError("server_error");
                context.Rejected();
                return;
            }
            if (user != null)
            {

                ClaimsIdentity oAuthIdentity = new ClaimsIdentity(context.Options.AuthenticationType);
                ClaimsIdentity cookiesIdentity = new ClaimsIdentity(context.Options.AuthenticationType);

                AuthenticationProperties properties = null;


                var claims = new List<Claim>()
                        {
                            new Claim(ClaimTypes.Sid, "01" ),
                            new Claim(ClaimTypes.Name, "jean jean"),
                            new Claim(ClaimTypes.MobilePhone, "0000"),
                            new Claim (ClaimTypes.Role, "User"),
                        };
                oAuthIdentity = new ClaimsIdentity(claims, Startup.AuthOP.AuthenticationType);

                properties = new AuthenticationProperties(new Dictionary<string, string>() { { "nom", "Jean jean" } }); 


                AuthenticationTicket ticket = new AuthenticationTicket(oAuthIdentity, properties);

                context.Validated(ticket);
                context.Request.Context.Authentication.SignIn(cookiesIdentity);

            }
            else
            {
                context.SetError("invalid_grant", "Invalid User Id or password'");
                context.Rejected();
            }
        }



        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (KeyValuePair<string,
            string> property in context.Properties.Dictionary)
            {
                context.AdditionalResponseParameters.Add(property.Key, property.Value);
            }

            return Task.FromResult<object>(null);
        }

        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            // Resource owner password credentials does not provide a client ID.
            if (true)
            {
                context.Validated();
            }

            return Task.FromResult<object>(null);
        }

        public override Task ValidateClientRedirectUri
        (OAuthValidateClientRedirectUriContext context)
        {
            if (context.ClientId == "44")
            {
                Uri expectedRootUri = new Uri(context.Request.Uri, "/");
                if (expectedRootUri.AbsoluteUri == context.RedirectUri)
                {
                    context.Validated();
                }
            }

            return Task.FromResult<object>(null);
        }


    }



}