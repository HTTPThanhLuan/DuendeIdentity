using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace RMG.ApiAuthorization.IdentityServer
{
    /// <summary>
    /// Generates oauth/openID parameter values for configured clients.
    /// </summary>
    public interface IClientRequestParametersProvider
    {
        /// <summary>
        /// Gets parameter values for the client with client id<paramref name="clientId"/>.
        /// </summary>
        /// <param name="context">The current <see cref="HttpContext"/>.</param>
        /// <param name="clientId">The client id for the client.</param>
        /// <returns>A <see cref="IDictionary{TKey, TValue}"/> containing the client parameters and their values.</returns>
        IDictionary<string, string> GetClientParameters(HttpContext context, string clientId);
    }
}
