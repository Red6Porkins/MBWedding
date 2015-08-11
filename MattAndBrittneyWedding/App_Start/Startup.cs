using MattAndBrittneyWedding.App_Start;
using MattAndBrittneyWedding.Providers;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Optimization;

[assembly: OwinStartup(typeof(MattAndBrittneyWedding.Startup))]
namespace MattAndBrittneyWedding
{
    public class Startup
    {
        public void Configuration (IAppBuilder app)
        {
            ConfigureOAuth(app);
            HttpConfiguration config = new HttpConfiguration();
            BundleConfig.RegisterBundles(BundleTable.Bundles); //I know this defeats the purpose of OWIN, but meh, this will only ever host on IIS and this is only to prevent Colin from trolling ...
            WebApiConfig.Register(config);
            app.UseWebApi(config);            
        }

        public void ConfigureOAuth (IAppBuilder app)
        {
            OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                Provider = new SimpleAuthorizationServerProvider()
            };

            // Token Generation
            app.UseOAuthAuthorizationServer(OAuthServerOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

        }
    }
}