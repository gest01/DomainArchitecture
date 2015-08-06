using System;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;

namespace Example.CrossCutting.Security
{
    public static class PrincipalExtensions
    {
        public static bool CanRead(this IPrincipal user)
        {
            return user.HasUserPermission();
        }

        public static String GetUserId(this IPrincipal principal)
        {
            return GetClaim(principal, CustomClaims.UserId).Value;
        }

        public static String GetLanguage(this IPrincipal principal)
        {
            return GetClaim(principal, CustomClaims.Language).Value;
        }

        public static String GetEmail(this IPrincipal principal)
        {
            return GetClaim(principal, ClaimTypes.Email).Value;
        }

        public static String GetDisplayName(this IPrincipal principal)
        {
            return GetClaim(principal, ClaimTypes.GivenName).Value;
        }

        public static bool IsAdmin(this IPrincipal user)
        {
            if (user.Identity.IsAuthenticated)
            {
                if (Permissions.AdminGroups.Length > 0 && Permissions.AdminGroups.Any(user.IsInRole))
                    return true;
            }

            return false;
        }

        public static bool IsUser(this IPrincipal user)
        {
            if (user.Identity.IsAuthenticated)
            {
                return true;

                // TODO Check for Roles / Groups etc..
                //if (Permissions.Users.Length > 0 && Permissions.Users.Contains(user.Identity.Name, StringComparer.OrdinalIgnoreCase))
                //    return true;

                //if (Permissions.UserGroups.Length > 0 && Permissions.UserGroups.Any(user.IsInRole))
                //    return true;
            }

            return false;
        }

        public static bool HasUserPermission(this IPrincipal user)
        {
            return user.IsUser() || user.IsAdmin();
        }

        private static Claim GetClaim(this IPrincipal principal, String claimType)
        {
            ClaimsPrincipal user = principal as ClaimsPrincipal;
            if (user != null)
            {
                var claim = user.FindFirst(claimType);
                if (claim != null)
                {
                    return claim;
                }
            }

            throw new ArgumentException("Unable to read ClaimType '" + claimType + "' from principal!");
        }
    }

}
