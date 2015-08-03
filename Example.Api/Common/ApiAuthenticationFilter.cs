using System;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Filters;
using Example.CrossCutting;
using Example.CrossCutting.Logging;
using Example.CrossCutting.Security;

namespace Example.Api.Common
{
    internal sealed class ApiAuthenticationFilter : FilterAttribute, IAuthenticationFilter
    {
        private readonly ILogger _log = ObjectServices.Logger.CreateLogger(typeof(ApiAuthenticationFilter));

        public System.Threading.Tasks.Task AuthenticateAsync(HttpAuthenticationContext context, System.Threading.CancellationToken cancellationToken)
        {
            OnAuthentication(context);
            return Task.FromResult(0);
        }

        /// <summary>
        /// Authenticates the request.
        /// </summary>
        /// <param name="context">The authentication context.</param>
        private void OnAuthentication(HttpAuthenticationContext context)
        {
            try
            {
                ClaimsPrincipal user = context.Principal as ClaimsPrincipal;
                ClaimsIdentity identity = user.Identity as ClaimsIdentity;

                // TODO  Add custom claims
                identity.AddClaim(new Claim(CustomClaims.Language , "me@bla.com", typeof(String).FullName));

                Thread.CurrentPrincipal = context.Principal = user;
            }
            catch(Exception ex)
            {
                _log.Error("*** API AUTHENTICATION ERROR ***\r\n{0}", ex.ToString());
            }
        }

        public System.Threading.Tasks.Task ChallengeAsync(HttpAuthenticationChallengeContext context, System.Threading.CancellationToken cancellationToken)
        {
            return Task.FromResult(0);
        }
    }
}