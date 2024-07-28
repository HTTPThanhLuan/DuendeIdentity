using Microsoft.AspNetCore.Hosting;
using System.Collections.Generic;

namespace RMG.ApiAuthorization.IdentityServer
{
    internal class IdentityServerJwtDescriptor : IIdentityServerJwtDescriptor
    {
        public IWebHostEnvironment Environment
        {
            get;
        }

        public IdentityServerJwtDescriptor(IWebHostEnvironment environment)
        {
            Environment = environment;
        }

        public IDictionary<string, ResourceDefinition> GetResourceDefinitions()
        {
            return new Dictionary<string, ResourceDefinition>
            {
                [Environment.ApplicationName + "API"] = new ResourceDefinition
                {
                    Profile = "IdentityServerJwt"
                }
            };
        }
    }
}
