using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMG.ApiAuthorization.IdentityServer
{
    internal class ResourceDefinition : ServiceDefinition
    {
        public string Scopes { get; set; }
    }
}
