using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RMG.IdentityServer.Services;

namespace IdentityServerHost.Pages.Logout;

[SecurityHeaders]
[AllowAnonymous]
public class LoggedOut : PageModel
{
    private readonly IIdentityServerInteractionService _interactionService;
        
    public LoggedOutViewModel View { get; set; }

    public LoggedOut(IIdentityServerInteractionService interactionService)
    {
        _interactionService = interactionService;
    }

    public async Task OnGet(string logoutId)
    {
        // get context information (client name, post logout redirect URI and iframe for federated signout)
        var logout = await _interactionService.GetLogoutContextAsync(logoutId);
       
        string postLogoutRedirectUri = logout.PostLogoutRedirectUri;
        if(string.IsNullOrEmpty(postLogoutRedirectUri))
            postLogoutRedirectUri = Clients.List.FirstOrDefault(c => logout.ClientId==c.ClientId).PostLogoutRedirectUris.FirstOrDefault();

        View = new LoggedOutViewModel
        {
            AutomaticRedirectAfterSignOut = LogoutOptions.AutomaticRedirectAfterSignOut,
            PostLogoutRedirectUri = postLogoutRedirectUri,
            ClientName = String.IsNullOrEmpty(logout?.ClientName) ? logout?.ClientId : logout?.ClientName,
            SignOutIframeUrl = logout?.SignOutIFrameUrl
        };
    }
}