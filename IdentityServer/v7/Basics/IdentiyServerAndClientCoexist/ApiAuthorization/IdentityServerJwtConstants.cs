using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMG.ApiAuthorization.IdentityServer
{
    //
    // Summary:
    //     Constants for a default API authentication handler.
    public class IdentityServerJwtConstants
    {
        //
        // Summary:
        //     Scheme used for the default API policy authentication scheme.
        public const string IdentityServerJwtScheme = "IdentityServerJwt";

        //
        // Summary:
        //     Scheme used for the underlying default API JwtBearer authentication scheme.
        public const string IdentityServerJwtBearerScheme = "IdentityServerJwtBearer";
    }
}
