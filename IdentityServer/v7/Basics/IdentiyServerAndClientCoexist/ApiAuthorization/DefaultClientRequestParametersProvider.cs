using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using RMG.IdentityServer.Extensions;
using RMG.IdentityServer.Services;

namespace RMG.ApiAuthorization.IdentityServer
{
    internal class DefaultClientRequestParametersProvider : IClientRequestParametersProvider
    {
        public DefaultClientRequestParametersProvider(
            IAbsoluteUrlFactory urlFactory,
            IOptions<ApiAuthorizationOptions> options,
            IIssuerNameService uIssuerNameService)
        {
            UrlFactory = urlFactory;
            Options = options;
            UIssuerNameService = uIssuerNameService;
        }

        public IAbsoluteUrlFactory UrlFactory { get; }

        public IOptions<ApiAuthorizationOptions> Options { get; }
        public IIssuerNameService UIssuerNameService { get; }

        public IDictionary<string, string> GetClientParameters(HttpContext context, string clientId)
        {
            var client = Options.Value.Clients[clientId];
            var authority = UIssuerNameService.GetCurrentAsync().GetAwaiter().GetResult();// context.GetIdentityServerIssuerUri();
            var responseType = "";
            if (!client.Properties.TryGetValue(ApplicationProfilesPropertyNames.Profile, out var type))
            {
                throw new InvalidOperationException($"Can't determine the type for the client '{clientId}'");
            }

            switch (type)
            {
                case ApplicationProfiles.IdentityServerSPA:
                case ApplicationProfiles.SPA:
                case ApplicationProfiles.NativeApp:
                    responseType = "code";
                    break;
                default:
                    throw new InvalidOperationException($"Invalid application type '{type}' for '{clientId}'.");
            }

            return new Dictionary<string, string>
            {
                ["authority"] = authority,
                ["client_id"] = client.ClientId,
                ["redirect_uri"] = UrlFactory.GetAbsoluteUrl(context, client.RedirectUris.First()),
                ["post_logout_redirect_uri"] = UrlFactory.GetAbsoluteUrl(context, client.PostLogoutRedirectUris.First()),
                ["response_type"] = responseType,
                ["scope"] = string.Join(" ", client.AllowedScopes)
            };
        }
    }

}
