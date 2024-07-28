// Copyright (c) Duende Software. All rights reserved.
// See LICENSE in the project root for license information.

using Duende.IdentityServer;
using Duende.IdentityServer.Services.KeyManagement;
using Duende.IdentityServer.Stores;
using IdentityServerHost;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using System.Security.Cryptography.X509Certificates;
using System.Text;

internal static class HostingExtensions
{
    public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddRazorPages();

        var idsvrBuilder = builder.Services.AddIdentityServer(options =>
        {
            options.Events.RaiseErrorEvents = true;
            options.Events.RaiseInformationEvents = true;
            options.Events.RaiseFailureEvents = true;
            options.Events.RaiseSuccessEvents = true;

            // see https://docs.duendesoftware.com/identityserver/v6/fundamentals/resources/api_scopes
            options.EmitStaticAudienceClaim = true;
            options.PushedAuthorization.AllowUnregisteredPushedRedirectUris = true;
        })
        .AddTestUsers(TestUsers.Users);

             

           

        idsvrBuilder.AddInMemoryIdentityResources(Resources.Identity);
        idsvrBuilder.AddInMemoryApiScopes(Resources.ApiScopes);
        idsvrBuilder.AddInMemoryApiResources(Resources.ApiResources);
        idsvrBuilder.AddInMemoryClients(Clients.List);


        #region Store The SignKey in Memory
        //Key must be at least 32 character.      
        var signinKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("You_Need_To_Provide_A_Longer_Secret_Key_Here"));
        var creds = new SigningCredentials(signinKey, SecurityAlgorithms.HmacSha256Signature);
        var k = new InMemorySigningCredentialsStore(creds);
        builder.Services.AddSingleton<ISigningCredentialStore>(k); //Using Memory To Store the SigninKey in tead of files in keys folder/

        #endregion


        #region Store The SignKey in Files (in keys folder)

        // builder.Services.AddSingleton<ISigningCredentialStore, AutomaticKeyManagerKeyStore>();

        #endregion



        // this is only needed for the JAR and JWT samples and adds supports for JWT-based client authentication
        idsvrBuilder.AddJwtBearerClientAuthentication();

        builder.Services.AddAuthentication()
            .AddOpenIdConnect("Google", "Sign-in with Google", options =>
            {
                options.SignInScheme = IdentityServerConstants.ExternalCookieAuthenticationScheme;
                options.ForwardSignOut = IdentityServerConstants.DefaultCookieAuthenticationScheme;

                options.Authority = "https://accounts.google.com/";
                options.ClientId = "708778530804-rhu8gc4kged3he14tbmonhmhe7a43hlp.apps.googleusercontent.com";

                options.CallbackPath = "/signin-google";
                options.Scope.Add("email");
                //Disable x-client-SKU and x-client-ver headers (security issue)
                options.DisableTelemetry = true;
            });

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
        app.UseIdentityServer();
        app.UseAuthorization();
        app.MapRazorPages();

        return app;
    }
}
