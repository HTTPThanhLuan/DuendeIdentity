using Microsoft.IdentityModel.Protocols;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System.Threading;
using System.Threading.Tasks;

namespace RMG.ApiAuthorization.IdentityServer
{
    internal class StaticConfigurationManager : IConfigurationManager<OpenIdConnectConfiguration>
    {
        private readonly Task<OpenIdConnectConfiguration> _configuration;

        public StaticConfigurationManager(OpenIdConnectConfiguration configuration)
        {
            _configuration = Task.FromResult(configuration);
        }

        public Task<OpenIdConnectConfiguration> GetConfigurationAsync(CancellationToken cancel)
        {
            return _configuration;
        }

        public void RequestRefresh()
        {
        }
    }
}
