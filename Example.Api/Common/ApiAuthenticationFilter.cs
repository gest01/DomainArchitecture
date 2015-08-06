using System;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Filters;
using Example.Application;
using Example.CrossCutting;
using Example.CrossCutting.Logging;

namespace Example.Api.Common
{
    internal sealed class ApiAuthenticationFilter : FilterAttribute, IAuthenticationFilter
    {
        private readonly ILogger _log = ObjectServices.Logger.CreateLogger(typeof(ApiAuthenticationFilter));
        private readonly PrincipalFactory _userFactory = new PrincipalFactory();

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
            ClaimsPrincipal user = context.Principal as ClaimsPrincipal;

            try
            {
                Thread.CurrentPrincipal = context.Principal = _userFactory.TransformPrincipal(user);
            }
            catch(Exception ex)
            {
                _log.Error("*** API AUTHENTICATION ERROR ***\r\n{0}", ex.ToString());
                Thread.CurrentPrincipal = context.Principal = _userFactory.CreateAnonymous(user);
            }
        }

        public System.Threading.Tasks.Task ChallengeAsync(HttpAuthenticationChallengeContext context, System.Threading.CancellationToken cancellationToken)
        {
            return Task.FromResult(0);
        }
    }
}