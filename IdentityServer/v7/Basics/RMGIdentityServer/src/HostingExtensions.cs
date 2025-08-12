// Copyright (c) Duende Software. All rights reserved.
// See LICENSE in the project root for license information.


using IdentityServerHost;
using Microsoft.AspNetCore.Identity;
using RMG.IdentityServer;
using Serilog;

internal static class HostingExtensions
{
    public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddRazorPages();

        var idsvrBuilder = builder.Services.AddRMGIdentityServer(options =>
        {
            options.Events.RaiseErrorEvents = true;
            options.Events.RaiseInformationEvents = true;
            options.Events.RaiseFailureEvents = true;
            options.Events.RaiseSuccessEvents = true;
            options.DynamicProviders.SignOutScheme = IdentityConstants.ApplicationScheme;
            options.EmitStaticAudienceClaim = true;   
           
        })
            .AddTestUsers(TestUsers.Users);

        idsvrBuilder.AddInMemoryIdentityResources(Resources.Identity);
        idsvrBuilder.AddInMemoryApiScopes(Resources.ApiScopes);
        idsvrBuilder.AddInMemoryApiResources(Resources.ApiResources);
        idsvrBuilder.AddInMemoryClients(Clients.List);

        // this is only needed for the JAR and JWT samples and adds supports for JWT-based client authentication
        idsvrBuilder.AddJwtBearerClientAuthentication();

        builder.Services.AddAuthentication();
            //.AddOpenIdConnect("Google", "Sign-in with Google", options =>
            //{
            //    options.SignInScheme = IdentityServerConstants.ExternalCookieAuthenticationScheme;
            //    options.ForwardSignOut = IdentityServerConstants.DefaultCookieAuthenticationScheme;

            //    options.Authority = "https://accounts.google.com/";
            //    options.ClientId = "708778530804-rhu8gc4kged3he14tbmonhmhe7a43hlp.apps.googleusercontent.com";

            //    options.CallbackPath = "/signin-google";
            //    options.Scope.Add("email");
            //    //Disable x-client-SKU and x-client-ver headers (security issue)
            //    options.DisableTelemetry = true;
            //});

        return builder.Build();
    }
    
    public static WebApplication ConfigurePipeline(this WebApplication app)
    { 
        app.UseSerilogRequestLogging();

        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseStaticFiles();

        app.UseRouting();
        app.UseRMGIdentityServer();
        app.UseAuthorization();
        app.MapRazorPages();

        return app;
    }
}
