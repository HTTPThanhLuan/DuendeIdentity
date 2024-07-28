using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using RMG.IdentityServer.Configuration;

namespace RMG.ApiAuthorization.IdentityServer
{
    internal class AspNetConventionsConfigureOptions : IConfigureOptions<IdentityServerOptions>
    {
        public void Configure(IdentityServerOptions options)
        {
            options.Events.RaiseErrorEvents = true;
            options.Events.RaiseInformationEvents = true;
            options.Events.RaiseFailureEvents = true;
            options.Events.RaiseSuccessEvents = true;
            options.Authentication.CookieAuthenticationScheme = IdentityConstants.ApplicationScheme;
            options.UserInteraction.ErrorUrl = "/Home";
        }
    }
}
