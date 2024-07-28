// Copyright (c) Duende Software. All rights reserved.
// See LICENSE in the project root for license information.

using IdentityServerHost;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.AspNetCore.Authentication;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Protocols;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.SystemConsole.Themes;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;


Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateBootstrapLogger();

Log.Information("Starting up");

try
{

    var builder = WebApplication.CreateBuilder(args);
    
    builder.Host.UseSerilog((ctx, lc) => lc
        .MinimumLevel.Debug()
        .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
        .MinimumLevel.Override("Microsoft.Hosting.Lifetime", LogEventLevel.Information)
        .MinimumLevel.Override("System", LogEventLevel.Warning)
        .MinimumLevel.Override("Microsoft.AspNetCore.Authentication", LogEventLevel.Information)
        .Enrich.FromLogContext()
        .WriteTo.Console(outputTemplate: "[{Timestamp:HH:mm:ss} {Level}] {SourceContext}{NewLine}{Message:lj}{NewLine}{Exception}{NewLine}", theme: AnsiConsoleTheme.Code));

    builder.Services.AddControllers();

    // this API will accept any access token from the authority
    builder.Services.AddAuthentication()
         .AddIdentityServerJwt1();


      //builder.Services.Configure<JwtBearerOptions>(IdentityServerJwtConstants.IdentityServerJwtBearerScheme,
      //  options =>
      //  {
      //      options.TokenValidationParameters.ValidateIssuer = false;
      //  });


    //Working without Docker ===============
    //builder.Services.AddAuthentication("token")
    // // .AddIdentityServerJwt1();
    // .AddJwtBearer("token", options =>
    // {
    //     options.Authority = "https://localhost:32769";
    //     options.TokenValidationParameters.ValidateAudience = false;
    //     options.TokenValidationParameters.ValidateIssuer = false;

    //     options.TokenValidationParameters.ValidTypes = new[] { "at+jwt" };
    //     options.MapInboundClaims = false;



    // });
    //End Working without Docker ===============

    var app = builder
        .ConfigureServices()
        .ConfigurePipeline();

    app.UseAuthentication();
    app.UseAuthorization();

    app.MapControllers().RequireAuthorization();

    app.UseRouting();    

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Unhandled exception");
}
finally
{
    Log.Information("Shut down complete");
    Log.CloseAndFlush();
}


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