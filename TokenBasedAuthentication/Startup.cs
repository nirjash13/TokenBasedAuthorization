using System;
using System.Web.Http;
using AuthenticationServer.DataAccess.Interfaces;
using AuthenticationServer.DataAccess.Services;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using TokenBasedAuthentication;
using TokenBasedAuthentication.Infrastructure;

[assembly: OwinStartup(typeof(Startup))]

namespace TokenBasedAuthentication
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);

            ISecurityService securityService = new SecurityService();

            var authenticationServerProvider = new TokenBasedAuthenticationServerProvider(securityService);
            OAuthAuthorizationServerOptions options = new OAuthAuthorizationServerOptions
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                Provider = authenticationServerProvider
            };
            app.UseOAuthAuthorizationServer(options);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());


            HttpConfiguration config = new HttpConfiguration();
            WebApiConfig.Register(config);
        }
    }
}