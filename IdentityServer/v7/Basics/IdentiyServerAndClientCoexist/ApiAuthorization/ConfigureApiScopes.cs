using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using RMG.IdentityServer.Models;

namespace RMG.ApiAuthorization.IdentityServer
{
    internal class ConfigureApiScopes : IPostConfigureOptions<ApiAuthorizationOptions>
    {
        public void PostConfigure(string name, ApiAuthorizationOptions options)
        {
            AddResourceScopesToApiScopes(options);
        }

        private void AddResourceScopesToApiScopes(ApiAuthorizationOptions options)
        {
            foreach (var resource in options.ApiResources)
            {
                foreach (var scope in resource.Scopes)
                {
                    if (!options.ApiScopes.ContainsScope(scope))
                    {
                        options.ApiScopes.Add(new ApiScope(scope));
                    }
                }
            }
        }
    }
}
