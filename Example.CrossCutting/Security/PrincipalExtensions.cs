using System;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;

namespace Example.CrossCutting.Security
{
    public static class PrincipalExtensions
    {
        /// <summary>
        /// Liefert TRUE, falls der Benutzer Zugriff auf die Applikation hat, sonst false
        /// </summary>
        /// <param name="user">Benutzer</param>
        /// <returns>True falls Read Permission vorhanden, sonst false </returns>
        public static bool CanRead(this IPrincipal user)
        {
            return user.HasUserPermission(); // Es werden mindestens User Berechtigungen für den Zugriff benötigt.
        }


        /// <summary>
        /// Liefert den DisplayNamen. Bsp. Peter Meier
        /// </summary>
        /// <param name="principal">IPrincipal</param>
        /// <returns>DisplayNamen</returns>
        public static String GetDisplayName(this IPrincipal principal)
        {
            return GetClaim(principal, ClaimTypes.GivenName).Value;
        }

        /// <summary>
        /// Liefert TRUE falls der Benutzer ein Administrator ist, sonst FALSE
        /// </summary>
        /// <param name="user">IPrincipal</param>
        /// <returns>True / False</returns>
        public static bool IsAdmin(this IPrincipal user)
        {
            if (user.Identity.IsAuthenticated)
            {
                if (Permissions.AdminGroups.Length > 0 && Permissions.AdminGroups.Any(user.IsInRole))
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Liefert TRUE falls der Benutzer ein normaler User ist, sonst FALSE
        /// </summary>
        /// <param name="user">IPrincipal</param>
        /// <returns>True / False</returns>
        public static bool IsUser(this IPrincipal user)
        {
            if (user.Identity.IsAuthenticated)
            {
                if (Permissions.Users.Length > 0 && Permissions.Users.Contains(user.Identity.Name, StringComparer.OrdinalIgnoreCase))
                    return true;

                if (Permissions.UserGroups.Length > 0 && Permissions.UserGroups.Any(user.IsInRole))
                    return true;
            }

            return false;
        }


        /// <summary>
        /// Liefert TRUE falls der Benutzer User, SuperUser oder Admin ist
        /// </summary>
        /// <param name="user">IPrincipal</param>
        /// <returns>True / False</returns>
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
