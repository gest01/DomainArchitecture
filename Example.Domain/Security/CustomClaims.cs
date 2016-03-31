using System;

namespace Example.Domain.Security
{
    /// <summary>
    /// Definiert die spezifischen Claims
    /// </summary>
    public static class CustomClaims
    {
        /// <summary>
        /// http://identity/claims/language
        /// </summary>
        public const String Language = "http://identity/claims/language";


        /// <summary>
        /// http://identity/claims/userid
        /// </summary>
        public const String UserId = "http://identity/claims/userid";

    }
}
