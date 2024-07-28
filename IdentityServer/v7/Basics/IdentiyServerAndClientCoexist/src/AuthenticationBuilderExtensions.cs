using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Duende.IdentityServer.Stores;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Protocols;
using Duende.IdentityServer.Services;

namespace IdentityServerHost
{
    /// <summary>
    /// Extension methods to configure authentication for existing APIs coexisting with an Authorization Server.
    /// </summary>
    public static class AuthenticationBuilderExtensions1
    {
        private const string IdentityServerJwtNameSuffix = "API";

        private static readonly PathString DefaultIdentityUIPathPrefix =
            new PathString("/Identity");

        /// <summary>
        /// Adds an authentication handler for an API that coexists with an Authorization Server.
        /// </summary>
        /// <param name="builder">The <see cref="AuthenticationBuilder"/>.</param>
        /// <returns>The <see cref="AuthenticationBuilder"/>.</returns>
        public static AuthenticationBuilder AddIdentityServerJwt1(this AuthenticationBuilder builder)
        {
            var services = builder.Services;
          
            services.TryAddEnumerable(ServiceDescriptor
                .Transient<IConfigureOptions<JwtBearerOptions>, IdentityServerJwtBearerOptionsConfiguration1>(JwtBearerOptionsFactory));

            services.AddAuthentication(IdentityServerJwtConstants.IdentityServerJwtBearerScheme)                
                .AddJwtBearer(IdentityServerJwtConstants.IdentityServerJwtBearerScheme, null, o => { });

            return builder;

            static IdentityServerJwtBearerOptionsConfiguration1 JwtBearerOptionsFactory(IServiceProvider sp)
            {
                var schemeName = IdentityServerJwtConstants.IdentityServerJwtBearerScheme;

     
                var hostingEnvironment = sp.GetRequiredService<IWebHostEnvironment>();
                var apiName = hostingEnvironment.ApplicationName + IdentityServerJwtNameSuffix;

                return new IdentityServerJwtBearerOptionsConfiguration1(schemeName, apiName);
            }
        }
    }

    internal sealed class IdentityServerJwtBearerOptionsConfiguration1 : IConfigureNamedOptions<JwtBearerOptions>
    {
        private readonly string _scheme;
        private readonly string _apiName;
       

        public IdentityServerJwtBearerOptionsConfiguration1(
            string scheme,
            string apiName)
        {
            _scheme = scheme;
            _apiName = apiName;
         
        }

        public void Configure(string name, JwtBearerOptions options)
        {
                  

            if (string.Equals(name, _scheme, StringComparison.Ordinal))
            {
                options.Events = options.Events ?? new JwtBearerEvents();
                options.Events.OnMessageReceived = ResolveAuthorityAndKeysAsync;
                //   options.Audience = _apiName;
                options.TokenValidationParameters.ValidateAudience = false;
                options.Authority = options.Authority;
                options.TokenValidationParameters.ValidTypes = new[] { "at+jwt" };
                options.MapInboundClaims = false;
                var staticConfiguration = new OpenIdConnectConfiguration
                {
                    Issuer = options.Authority
                };

            
                var manager = new StaticConfigurationManager(staticConfiguration);
                options.ConfigurationManager = manager;
                options.TokenValidationParameters.ValidIssuer = options.Authority;
                options.TokenValidationParameters.NameClaimType = "name";
                options.TokenValidationParameters.RoleClaimType = "role";

                //options.TokenValidationParameters.ValidateIssuer = false; Up con set here or at the Program.cs  builder.Services.Configure<JwtBearerOptions>
            }
        }

        internal static async Task ResolveAuthorityAndKeysAsync(MessageReceivedContext messageReceivedContext)
        {
            var options = messageReceivedContext.Options;
            if (options.TokenValidationParameters.ValidIssuer == null || options.TokenValidationParameters.IssuerSigningKey == null)
            {
                var store = messageReceivedContext.HttpContext.RequestServices.GetRequiredService<ISigningCredentialStore>();
                var credential = await store.GetSigningCredentialsAsync();
                var store1 = messageReceivedContext.HttpContext.RequestServices.GetRequiredService<IIssuerNameService>();
                               
#pragma warning disable 0618
                options.Authority = options.Authority ?? store1.GetCurrentAsync().Result;//.GetIdentityServerIssuerUri();
#pragma warning restore 0618
                options.TokenValidationParameters.IssuerSigningKey = credential.Key;
                options.TokenValidationParameters.ValidIssuer = options.Authority;
            }
        }

        public void Configure(JwtBearerOptions options)
        {
        }
    }
}
