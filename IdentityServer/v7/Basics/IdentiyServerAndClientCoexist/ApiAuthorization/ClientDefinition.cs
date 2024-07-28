using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMG.ApiAuthorization.IdentityServer
{
    internal class ClientDefinition : ServiceDefinition
    {
        public string RedirectUri { get; set; }
        public string LogoutUri { get; set; }
        public string ClientSecret { get; set; }
    }
}
