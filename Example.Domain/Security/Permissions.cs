using System;
using System.Linq;

namespace Example.Domain.Security
{
    public static class Permissions
    {
        /// <summary>Liefert die Namen der Gruppe für User mit normalen Zugriffs-Berechtigungen</summary>
        internal readonly static String[] UserGroups = SplitString("GroupA, GroupB");

        /// <summary>Liefert alle AD Accounts von Usern mit normalen Zugriffs-Berechtigungen</summary>
        internal readonly static String[] Users = SplitString("ad\\usera; ad\\userb");

        /// <summary>Liefert die Namen der Gruppe für die Adminitratoren</summary>
        internal readonly static String[] AdminGroups = SplitString("AdminGroup");

        private static String[] SplitString(String value)
        {
            if (String.IsNullOrWhiteSpace(value))
                return new String[0];

            return value.Split(new String[] { ",", ";" }, StringSplitOptions.RemoveEmptyEntries)
                .Select(f => f.Trim())
                .ToArray();
        }

        /// <summary>
        /// Prüft ob ein String einer Admin-Gruppe entspricht.
        /// </summary>
        /// <param name="group">String</param>
        /// <returns>TRUE falls 'group' einer Admingruppe entspricht, sonst FALSE</returns>
        public static bool IsAdminGroup(String group)
        {
            if (String.IsNullOrWhiteSpace(group))
                return false;

            return Permissions.AdminGroups.Any(f => f == group);
        }
    }
}
