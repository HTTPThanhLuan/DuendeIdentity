
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using System;

namespace RMG.ApiAuthorization.IdentityServer
{
    //
    // Summary:
    //     Extension methods to configure authentication for existing APIs coexisting with
    //     an Authorization Server.
    public static class AuthenticationBuilderExtensions
    {
        private const string IdentityServerJwtNameSuffix = "API";

        private static readonly PathString DefaultIdentityUIPathPrefix = new PathString("/Identity");

        //
        // Summary:
        //     Adds an authentication handler for an API that coexists with an Authorization
        //     Server.
        //
        // Parameters:
        //   builder:
        //     The Microsoft.AspNetCore.Authentication.AuthenticationBuilder.
        //
        // Returns:
        //     The Microsoft.AspNetCore.Authentication.AuthenticationBuilder.
        public static AuthenticationBuilder AddIdentityServerJwt(this AuthenticationBuilder builder)
        {
            IServiceCollection services = builder.Services;
            services.TryAddSingleton<IIdentityServerJwtDescriptor, IdentityServerJwtDescriptor>();
            services.TryAddEnumerable(ServiceDescriptor.Transient<IConfigureOptions<JwtBearerOptions>, IdentityServerJwtBearerOptionsConfiguration>(new Func<IServiceProvider, IdentityServerJwtBearerOptionsConfiguration>(JwtBearerOptionsFactory)));
            services.AddAuthentication("IdentityServerJwt").AddPolicyScheme("IdentityServerJwt", null, delegate (PolicySchemeOptions options)
            {
                options.ForwardDefaultSelector = new Func<HttpContext, string>(new IdentityServerJwtPolicySchemeForwardSelector((string)DefaultIdentityUIPathPrefix, "IdentityServerJwtBearer").SelectScheme);
            }).AddJwtBearer("IdentityServerJwtBearer", null, delegate
            {
            });
            return builder;
            static IdentityServerJwtBearerOptionsConfiguration JwtBearerOptionsFactory(IServiceProvider sp)
            {
                IIdentityServerJwtDescriptor requiredService = sp.GetRequiredService<IIdentityServerJwtDescriptor>();
                string apiName = sp.GetRequiredService<IWebHostEnvironment>().ApplicationName + "API";
                return new IdentityServerJwtBearerOptionsConfiguration("IdentityServerJwtBearer", apiName, requiredService);
            }
        }
    }
}
