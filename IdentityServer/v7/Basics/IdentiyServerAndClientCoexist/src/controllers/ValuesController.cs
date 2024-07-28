

using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace IdentityServerHost.controllers
{
   
    [Route("api/[controller]")]
    [Authorize( AuthenticationSchemes = "IdentityServerJwtBearer")] //token
   // [Authorize(AuthenticationSchemes = "token")] //token
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/<controller>   : url to use => api/vs
        public string Get()
        {
            return "Hi from web api controller";
        }

       
    }
}
