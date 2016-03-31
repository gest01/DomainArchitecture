using System;
using System.Security.Claims;
using System.Security.Principal;
using Example.Domain.ValueObjects;

namespace Example.Domain.Security
{
    public sealed class PrincipalFactory
    {
        public IPrincipal TransformPrincipal(ClaimsPrincipal user)
        {
            UserInfo userinfo = LoadUserInfo(user.Identity.Name);
            if (userinfo != null)
            {
                ClaimsIdentity identity = user.Identity as ClaimsIdentity;

                identity.AddClaim(new Claim(CustomClaims.Language, userinfo.Language, typeof(String).FullName));
                identity.AddClaim(new Claim(CustomClaims.UserId, userinfo.UserId, typeof(String).FullName));

                identity.AddClaim(new Claim(ClaimTypes.Email, userinfo.Email, typeof(String).FullName));
                identity.AddClaim(new Claim(ClaimTypes.GivenName, userinfo.DisplayName, typeof(String).FullName));

                return user;
            }

            // TODO User not exists in userstore...

            return CreateAnonymous(user);
        }

        public IPrincipal CreateAnonymous(IPrincipal user)
        {
            return new AnonymousPrincipal(user);
        }

        private UserInfo LoadUserInfo(String userId)
        {
            // TODO 
            // 1. Check in Cache
            // 2. Load from Db / Ad etc...
            // 3. Cache by id

            return new UserInfo() {
                UserId = userId,
                DisplayName = "John Wayne",
                Email  = "john.wayne@world.com",
                Language = "en"
                
            };
        }

        private class AnonymousPrincipal : ClaimsPrincipal
        {
            public AnonymousPrincipal(IPrincipal principal)
                : base(new AnonymousIdentity(principal.Identity))
            { }
        }

        private class AnonymousIdentity : ClaimsIdentity
        {
            public AnonymousIdentity(IIdentity identity)
                : base(identity)
            { }

            public override bool IsAuthenticated
            {
                get
                {
                    return false;
                }
            }
        }
    }
}
