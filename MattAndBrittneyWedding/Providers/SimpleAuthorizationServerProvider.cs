using MattAndBrittneyWedding.Repository;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace MattAndBrittneyWedding.Providers
{
    public class SimpleAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }
 
        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
 
            //context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            using (MemberRepository _repo = new MemberRepository())
            {
                //IdentityUser user = await _repo.FindUser(context.UserName, context.Password);
                var UserAuth = await _repo.GetMember(context.UserName, context.Password);
 
                if (!UserAuth)
                {
                    context.SetError("invalid_grant", "The user name or password is incorrect.");
                    return;
                }
            }
 
            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            identity.AddClaim(new Claim("sub", context.UserName));
            identity.AddClaim(new Claim("role", "user"));
 
            context.Validated(identity);
        }
    }
}