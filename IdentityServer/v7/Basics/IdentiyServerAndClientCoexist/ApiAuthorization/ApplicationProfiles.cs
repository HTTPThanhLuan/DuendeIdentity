using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMG.ApiAuthorization.IdentityServer
{
    /// <summary>
    /// Constants for the different application profiles for applications in an authorization server.
    /// </summary>
    public static class ApplicationProfiles
    {
        /// <summary>
        /// The application is an external API registered with the authorization server.
        /// </summary>
        public const string API = "API";

        /// <summary>
        /// The application is an API that coexists with the authorization server.
        /// </summary>
        public const string IdentityServerJwt = "IdentityServerJwt";

        /// <summary>
        /// The application is an external single page application registered with the authorization server.
        /// </summary>
        public const string SPA = "SPA";

        /// <summary>
        /// The application is a single page application that coexists with the authorization server.
        /// </summary>
        public const string IdentityServerSPA = "IdentityServerSPA";

        /// <summary>
        /// The application is a native application like a mobile or desktop application.
        /// </summary>
        public const string NativeApp = "NativeApp";
    }
}
