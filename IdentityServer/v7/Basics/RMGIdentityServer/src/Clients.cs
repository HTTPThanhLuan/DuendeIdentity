// Copyright (c) Duende Software. All rights reserved.
// See LICENSE in the project root for license information.



using RMG.IdentityServer;
using RMG.IdentityServer.Models;

namespace IdentityServerHost;

public static class Clients
{
    public static IEnumerable<Client> List =>
        new[]
        {
            // client credentials flow sample
            new Client
            {
                ClientId = "client.credentials.sample",

                AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                ClientSecrets = { new Secret("secret".Sha256()) },

                AllowedScopes = { "scope1", "scope2" },
                 AllowAccessTokensViaBrowser =true,

            },
            
            // JWT-based client authentication sample
            new Client
            {
                ClientId = "jwt.client.credentials.sample",

                AllowedGrantTypes = GrantTypes.ClientCredentials,
                
                // this client uses an RSA key as client secret
                // and https://docs.duendesoftware.com/identityserver/v5/tokens/authentication/jwt/
                ClientSecrets =
                {
                    new Secret
                    {
                        Type = IdentityServerConstants.SecretTypes.JsonWebKey,
                        Value = """
                        {
                            "e":"AQAB",
                            "kid":"ZzAjSnraU3bkWGnnAqLapYGpTyNfLbjbzgAPbbW2GEA",
                            "kty":"RSA",
                            "n":"wWwQFtSzeRjjerpEM5Rmqz_DsNaZ9S1Bw6UbZkDLowuuTCjBWUax0vBMMxdy6XjEEK4Oq9lKMvx9JzjmeJf1knoqSNrox3Ka0rnxXpNAz6sATvme8p9mTXyp0cX4lF4U2J54xa2_S9NF5QWvpXvBeC4GAJx7QaSw4zrUkrc6XyaAiFnLhQEwKJCwUw4NOqIuYvYp_IXhw-5Ti_icDlZS-282PcccnBeOcX7vc21pozibIdmZJKqXNsL1Ibx5Nkx1F1jLnekJAmdaACDjYRLL_6n3W4wUp19UvzB1lGtXcJKLLkqB6YDiZNu16OSiSprfmrRXvYmvD8m6Fnl5aetgKw"
                        }
                        """
                    }
                },

                AllowedScopes = { "scope1", "scope2" }
            },
            
            // introspection sample
            new Client
            {
                ClientId = "introspection.sample",

                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets = { new Secret("secret".Sha256()) },

                AccessTokenType = AccessTokenType.Reference,

                AllowedScopes = { "scope1", "scope2" }
            },

            new Client
            {
                ClientId = "interactive.mvc.sample3",
                ClientSecrets = { new Secret("secret".Sha256()) },

                AllowedGrantTypes = GrantTypes.Code,

                RedirectUris = { "https://localhost:7062/signin-oidc" },
                FrontChannelLogoutUri = "https://localhost:7062/signout-oidc",
                PostLogoutRedirectUris = { "https://localhost:7062/signout-callback-oidc" },

                AllowOfflineAccess = true,
                AllowedScopes = { "openid", "profile", "scope1", "scope2" }
            },
            new Client
            {
                ClientId = "interactive.mvc.sample",
                ClientSecrets = { new Secret("secret".Sha256()) },

                AllowedGrantTypes = GrantTypes.Code,

                RedirectUris = { "https://localhost:44300/signin-oidc" },
                FrontChannelLogoutUri = "https://localhost:44300/signout-oidc",
                PostLogoutRedirectUris = { "https://localhost:44300/signout-callback-oidc" },

                AllowOfflineAccess = true,
                AllowedScopes = { "openid", "profile", "scope1", "scope2" }
            },

            // MVC basic sample
         
            
            // MVC basic sample with token management
            // this client has a short access token lifetime to experiment with automatic refresh
            new Client
            {
                ClientId = "interactive.mvc.sample.short.token.lifetime",
                ClientSecrets = { new Secret("secret".Sha256()) },

                AllowedGrantTypes = GrantTypes.Code,
                AccessTokenLifetime = 75,

                RedirectUris = { "https://localhost:7053/signin-oidc" },
                FrontChannelLogoutUri = "https://localhost:7053/signout-oidc",
                PostLogoutRedirectUris = { "https://localhost:7053/signout-callback-oidc" },

                AllowOfflineAccess = true,
                AllowedScopes = { "openid", "profile", "scope1", "scope2" }
            },
            
            // MVC sample using JAR (signed authorize requests) and JWTs for client authentication
            new Client
            {
                ClientId = "interactive.mvc.sample.jarjwt",
                
                // force client to use signed authorize request
                RequireRequestObject = true,
                
                // this client uses an RSA key as client secret
                // this key is used for both validating the signature on the authorize request
                // and for client authentication
                // see https://docs.duendesoftware.com/identityserver/v5/advanced/jar/
                // and https://docs.duendesoftware.com/identityserver/v5/tokens/authentication/jwt/
                ClientSecrets =
                {
                    new Secret
                    {
                        Type = IdentityServerConstants.SecretTypes.JsonWebKey,
                        Value = """
                        {
                            "e":"AQAB",
                            "kid":"ZzAjSnraU3bkWGnnAqLapYGpTyNfLbjbzgAPbbW2GEA",
                            "kty":"RSA",
                            "n":"wWwQFtSzeRjjerpEM5Rmqz_DsNaZ9S1Bw6UbZkDLowuuTCjBWUax0vBMMxdy6XjEEK4Oq9lKMvx9JzjmeJf1knoqSNrox3Ka0rnxXpNAz6sATvme8p9mTXyp0cX4lF4U2J54xa2_S9NF5QWvpXvBeC4GAJx7QaSw4zrUkrc6XyaAiFnLhQEwKJCwUw4NOqIuYvYp_IXhw-5Ti_icDlZS-282PcccnBeOcX7vc21pozibIdmZJKqXNsL1Ibx5Nkx1F1jLnekJAmdaACDjYRLL_6n3W4wUp19UvzB1lGtXcJKLLkqB6YDiZNu16OSiSprfmrRXvYmvD8m6Fnl5aetgKw"
                        }
                        """
                    }
                },

                AllowedGrantTypes = GrantTypes.Code,

                RedirectUris = { "https://localhost:44300/signin-oidc" },
                FrontChannelLogoutUri = "https://localhost:44300/signout-oidc",
                PostLogoutRedirectUris = { "https://localhost:44300/signout-callback-oidc" },

                AllowOfflineAccess = true,
                AllowedScopes = { "openid", "profile", "scope1", "scope2" }
            },





             new Client
            {
                ClientId = "client2",
                ClientSecrets = { new Secret("secret".Sha256()) },

                AllowedGrantTypes = GrantTypes.Code,

                RedirectUris = { "https://localhost:7053/signin-oidc" },
                BackChannelLogoutUri = "https://localhost:7053/logout",
                PostLogoutRedirectUris = { "https://localhost:7053/signout-callback-oidc" },

                AllowOfflineAccess = true,
                AllowedScopes = { "openid", "profile", "scope1", "scope2" }
            },



            new Client
            {
                ClientId = "mvc.par",
                ClientName = "MVC PAR Client",

                ClientSecrets =
                {
                    new Secret("secret".Sha256())
                },

                RequireRequestObject = false,

                AllowedGrantTypes = GrantTypes.Code,
                             

                // Note that redirect uris are optional for PAR clients when the
                // AllowUnregisteredPushedRedirectUris flag is enabled
                // RedirectUris = { "https://localhost:44300/signin-oidc" },

                FrontChannelLogoutUri = "https://localhost:7053/signout-oidc",
                PostLogoutRedirectUris = { "https://localhost:7053/signout-callback-oidc" },

                AllowOfflineAccess = true,

                AllowedScopes = { "openid", "profile", "scope1", "scope2" }
            },
             new Client
            {
                ClientId = "client0",
                ClientSecrets = { new Secret("secret".Sha256()) },
                ClientName = "My OAuth Client",
                AllowedGrantTypes = GrantTypes.Code,
                RequirePkce = false, // set true if you want PKCE with AddOAuth
                AllowPlainTextPkce = false,

                RedirectUris = { "https://rushmoresystem01.azurewebsites.net/signin-oauth" },
                PostLogoutRedirectUris = { "https://rushmoresystem01.azurewebsites.net/" },

                AlwaysIncludeUserClaimsInIdToken = true,

                AllowOfflineAccess = true,
                AllowedScopes = { "openid", "profile", "scope1", "scope2" }
            },


            new Client
            {
                ClientId = "client_eli",
                ClientSecrets = { new Secret("secret".Sha256()) },
                ClientName = "My OAuth Client",
                AllowedGrantTypes = GrantTypes.Code,
                RequirePkce = false, // set true if you want PKCE with AddOAuth
                AllowPlainTextPkce = false,

                RedirectUris = { "https://rushmoresystem01.azurewebsites.net/eli/signin-oauth" },
                PostLogoutRedirectUris = { "https://rushmoresystem01.azurewebsites.net/eli/" },

                AlwaysIncludeUserClaimsInIdToken = true,

                AllowOfflineAccess = true,
                AllowedScopes = { "openid", "profile", "scope1", "scope2" }
            },

            new Client
            {
                ClientId = "client_es",
                ClientSecrets = { new Secret("secret".Sha256()) },
                ClientName = "My OAuth Client",
                AllowedGrantTypes = GrantTypes.Code,
                RequirePkce = false, // set true if you want PKCE with AddOAuth
                AllowPlainTextPkce = false,

                RedirectUris = { "https://rushmoresystem01.azurewebsites.net/es/signin-oauth" },
                PostLogoutRedirectUris = { "https://rushmoresystem01.azurewebsites.net/es/" },

                AlwaysIncludeUserClaimsInIdToken = true,

                AllowOfflineAccess = true,
                AllowedScopes = { "openid", "profile", "scope1", "scope2" }
            }
            ,

            new Client
            {
                ClientId = "client_interview",
                ClientSecrets = { new Secret("secret".Sha256()) },
                ClientName = "My OAuth Client",
                AllowedGrantTypes = GrantTypes.Code,
                RequirePkce = false, // set true if you want PKCE with AddOAuth
                AllowPlainTextPkce = false,

                RedirectUris = { "https://rushmoresystem01.azurewebsites.net/interview/signin-oauth" },
                PostLogoutRedirectUris = { "https://rushmoresystem01.azurewebsites.net/interview/" },

                AlwaysIncludeUserClaimsInIdToken = true,

                AllowOfflineAccess = true,
                AllowedScopes = { "openid", "profile", "scope1", "scope2" }
            }
             ,

            new Client
            {
                ClientId = "client_cws",
                ClientSecrets = { new Secret("secret".Sha256()) },
                ClientName = "My OAuth Client",
                AllowedGrantTypes = GrantTypes.Code,
                RequirePkce = false, // set true if you want PKCE with AddOAuth
                AllowPlainTextPkce = false,

                RedirectUris = { "https://rushmoresystem01.azurewebsites.net/cws/signin-oauth" },
                PostLogoutRedirectUris = { "https://rushmoresystem01.azurewebsites.net/cws/" },

                AlwaysIncludeUserClaimsInIdToken = true,

                AllowOfflineAccess = true,
                AllowedScopes = { "openid", "profile", "scope1", "scope2" }
            }
             ,

            new Client
            {
                ClientId = "client_appeals",
                ClientSecrets = { new Secret("secret".Sha256()) },
                ClientName = "My OAuth Client",
                AllowedGrantTypes = GrantTypes.Code,
                RequirePkce = false, // set true if you want PKCE with AddOAuth
                AllowPlainTextPkce = false,

                RedirectUris = { "https://rushmoresystem01.azurewebsites.net/appeals/signin-oauth" },
                PostLogoutRedirectUris = { "https://rushmoresystem01.azurewebsites.net/appeals/" },

                AlwaysIncludeUserClaimsInIdToken = true,

                AllowOfflineAccess = true,
                AllowedScopes = { "openid", "profile", "scope1", "scope2" }
            }
             ,

            new Client
            {
                ClientId = "client_access",
                ClientSecrets = { new Secret("secret".Sha256()) },
                ClientName = "My OAuth Client",
                AllowedGrantTypes = GrantTypes.Code,
                RequirePkce = false, // set true if you want PKCE with AddOAuth
                AllowPlainTextPkce = false,

                RedirectUris = { "https://rushmoresystem01.azurewebsites.net/access/signin-oauth" },
                PostLogoutRedirectUris = { "https://rushmoresystem01.azurewebsites.net/access/" },

                AlwaysIncludeUserClaimsInIdToken = true,

                AllowOfflineAccess = true,
                AllowedScopes = { "openid", "profile", "scope1", "scope2" }
            }
            ,

            new Client
            {
                ClientId = "client_css",
                ClientSecrets = { new Secret("secret".Sha256()) },
                ClientName = "My OAuth Client",
                AllowedGrantTypes = GrantTypes.Code,

                RedirectUris = { "https://rushmoresystem02.azurewebsites.net/Identity/Account/ExternalLogin?handler=Callback" },
                PostLogoutRedirectUris = { "https://rushmoresystem02.azurewebsites.net/Identity/Account/Login" },

                AlwaysIncludeUserClaimsInIdToken = true,

                AllowOfflineAccess = true,
                AllowedScopes = { "openid", "profile", "scope1", "scope2" }
            }
            ,

            new Client
            {
                ClientId = "client_eligi2",
                ClientSecrets = { new Secret("secret".Sha256()) },
                ClientName = "My OAuth Client",
                AllowedGrantTypes = GrantTypes.Code,
                RequirePkce = false, // set true if you want PKCE with AddOAuth
                AllowPlainTextPkce = false,
                RedirectUris = { "https://rushmoresystem03.azurewebsites.net/signin-oauth" },
                PostLogoutRedirectUris = { "https://rushmoresystem03.azurewebsites.net/" },
                //RedirectUris = { "https://localhost:44374/signin-oauth" },
                //PostLogoutRedirectUris = { "https://localhost:44374/" },
                AlwaysIncludeUserClaimsInIdToken = true,

                AllowOfflineAccess = true,
                AllowedScopes = { "openid", "profile", "scope1", "scope2" }
            }
             ,

            new Client
            {
                ClientId = "client_cse",
                ClientSecrets = { new Secret("secret".Sha256()) },
                ClientName = "My OAuth Client",
                AllowedGrantTypes = GrantTypes.Code,
                RequirePkce = false, // set true if you want PKCE with AddOAuth
                AllowPlainTextPkce = false,
                RedirectUris = { "https://rushmoresystem04.azurewebsites.net/signin-oauth" },
                PostLogoutRedirectUris = { "https://rushmoresystem04.azurewebsites.net/" },
                //RedirectUris = { "https://localhost:44321/signin-oauth" },
                //PostLogoutRedirectUris = { "https://localhost:44321/" },
                AlwaysIncludeUserClaimsInIdToken = true,

                AllowOfflineAccess = true,
                AllowedScopes = { "openid", "profile", "scope1", "scope2" }
            }
              ,

            new Client
            {
                ClientId = "client_childwelfare",
                ClientSecrets = { new Secret("secret".Sha256()) },
                ClientName = "My OAuth Client",
                AllowedGrantTypes = GrantTypes.Code,
                RequirePkce = false, // set true if you want PKCE with AddOAuth
                AllowPlainTextPkce = false,
                RedirectUris = { "https://rushmoresystem05.azurewebsites.net/signin-oauth" },
                PostLogoutRedirectUris = { "https://rushmoresystem05.azurewebsites.net/" },
                //RedirectUris = { "https://localhost:44311/signin-oauth" },
                //PostLogoutRedirectUris = { "https://localhost:44311/" },
                AlwaysIncludeUserClaimsInIdToken = true,

                AllowOfflineAccess = true,
                AllowedScopes = { "openid", "profile", "scope1", "scope2" }
            },
               new Client
            {
                ClientId = "client_dd",
                ClientSecrets = { new Secret("secret".Sha256()) },
                ClientName = "My OAuth Client",
                AllowedGrantTypes = GrantTypes.Hybrid,
                RequirePkce = false,
                //RedirectUris = { "https://localhost:44339/signin-oidc" },
                //PostLogoutRedirectUris = { "https://localhost:44339/LogOn.aspx" }, 
                RedirectUris = { "https://rushmoresystem06.azurewebsites.net/signin-oidc" },
                PostLogoutRedirectUris = { "https://rushmoresystem06.azurewebsites.net/LogOn.aspx" },
                AllowOfflineAccess = true,
                AllowedScopes = { "openid", "profile", "scope1", "scope2" },
                AlwaysIncludeUserClaimsInIdToken = true,
            }
            ,
            new Client
            {
                ClientId = "client_02",
                ClientSecrets = { new Secret("secret".Sha256()) },
                ClientName = "My OAuth Client",
                AllowedGrantTypes = GrantTypes.Code,
                RequirePkce = false, // set true if you want PKCE with AddOAuth
                AllowPlainTextPkce = false,

                RedirectUris = { "https://rushmoresystem07.azurewebsites.net/signin-oauth" },
                PostLogoutRedirectUris = { "https://rushmoresystem07.azurewebsites.net/" },

                AlwaysIncludeUserClaimsInIdToken = true,
                AllowOfflineAccess = true,
                AllowedScopes = { "openid", "profile", "scope1", "scope2" }
            }
            ,

            new Client
            {
                ClientId = "client_eta",
                ClientSecrets = { new Secret("secret".Sha256()) },
                ClientName = "My OAuth Client",
                AllowedGrantTypes = GrantTypes.Code,
                RequirePkce = false, // set true if you want PKCE with AddOAuth
                AllowPlainTextPkce = false,

                RedirectUris = { "https://rushmoresystem07.azurewebsites.net/eta/signin-oauth" },
                PostLogoutRedirectUris = { "https://rushmoresystem07.azurewebsites.net/eta/" },

                AlwaysIncludeUserClaimsInIdToken = true,
                AllowOfflineAccess = true,
                AllowedScopes = { "openid", "profile", "scope1", "scope2" }
            }
            ,

            new Client
            {
                ClientId = "client_ihss",
                ClientSecrets = { new Secret("secret".Sha256()) },
                ClientName = "My OAuth Client",
                AllowedGrantTypes = GrantTypes.Code,
                RequirePkce = false, // set true if you want PKCE with AddOAuth
                AllowPlainTextPkce = false,

                RedirectUris = { "https://rushmoresystem07.azurewebsites.net/ihss/signin-oauth" },
                PostLogoutRedirectUris = { "https://rushmoresystem07.azurewebsites.net/ihss/" },

                AlwaysIncludeUserClaimsInIdToken = true,
                AllowOfflineAccess = true,
                AllowedScopes = { "openid", "profile", "scope1", "scope2" }
            }
             ,

            new Client
            {
                ClientId = "client_contact",
                ClientSecrets = { new Secret("secret".Sha256()) },
                ClientName = "My OAuth Client",
                AllowedGrantTypes = GrantTypes.Code,
                RequirePkce = false, // set true if you want PKCE with AddOAuth
                AllowPlainTextPkce = false,

                RedirectUris = { "https://rushmoresystem07.azurewebsites.net/contact/signin-oauth" },
                PostLogoutRedirectUris = { "https://rushmoresystem07.azurewebsites.net/contact/" },

                AlwaysIncludeUserClaimsInIdToken = true,
                AllowOfflineAccess = true,
                AllowedScopes = { "openid", "profile", "scope1", "scope2" }
            },
               new Client
            {
                ClientId = "client_nebraska_mortality",
                ClientSecrets = { new Secret("secret".Sha256()) },
                ClientName = "My OAuth Client",
                AllowedGrantTypes = GrantTypes.Hybrid,
                RequirePkce = false,
                //RedirectUris = { "https://localhost:44334/signin-oidc" },
                //PostLogoutRedirectUris = { "https://localhost:44334/LogOn.aspx" }, 
                RedirectUris = { "https://rushmoresystem08.azurewebsites.net/signin-oidc" },
                PostLogoutRedirectUris = { "https://rushmoresystem08.azurewebsites.net/LogOn.aspx" },
                AllowOfflineAccess = true,
                AllowedScopes = { "openid", "profile", "scope1", "scope2" },
                AlwaysIncludeUserClaimsInIdToken = true,
            },
            new Client
            {
                ClientId = "client_nebraska_CIR",
                ClientSecrets = { new Secret("secret".Sha256()) },
                ClientName = "My OAuth Client",
                AllowedGrantTypes = GrantTypes.Hybrid,
                RequirePkce = false,
                //RedirectUris = { "https://localhost:44334/signin-oidc" },
                //PostLogoutRedirectUris = { "https://localhost:44334/LogOn.aspx" },
                RedirectUris = { "https://rushmoresystem09.azurewebsites.net/signin-oidc" },
                PostLogoutRedirectUris = { "https://rushmoresystem09.azurewebsites.net/LogOn.aspx" },
                AllowOfflineAccess = true,
                AllowedScopes = { "openid", "profile", "scope1", "scope2" },
                AlwaysIncludeUserClaimsInIdToken = true,
            },
            new Client
                {
                    ClientId = "client_NortDakota_DD",
                    ClientName = "Razor Pages App",
                    AllowedGrantTypes = GrantTypes.Code,
                    RequirePkce = true,
                    ClientSecrets = { new Secret("secret".Sha256()) },
                    RedirectUris = {"https://rushmoresystem11.azurewebsites.net/signin-oidc" },
                    PostLogoutRedirectUris = {"https://rushmoresystem11.azurewebsites.net"},
                    //RedirectUris = {"https://localhost:44328/signin-oidc" },
                    //PostLogoutRedirectUris = {"https://localhost:44328"},
                    AllowedScopes = { "openid", "profile" },
                    AllowOfflineAccess = true,
                    AlwaysIncludeUserClaimsInIdToken = true,
                }
              , new Client
            {
                ClientId = "client_pennsylvania",
                ClientSecrets = { new Secret("secret".Sha256()) },
                RequirePkce = true,
                AllowedGrantTypes = GrantTypes.Code,
                RedirectUris = {"https://rushmoresystem10.azurewebsites.net/signin-oidc" },
                PostLogoutRedirectUris = {"https://rushmoresystem10.azurewebsites.net", "https://rushmoresystem10.azurewebsites.net/LMS"},

                //RedirectUris = { "https://localhost:44329/signin-oidc" },
                //PostLogoutRedirectUris = {"https://localhost:44329" , "https://localhost:44329/LMS" },

                AllowOfflineAccess = true,
                AllowedScopes = { "openid", "profile", "scope1", "scope2" },
                AlwaysIncludeUserClaimsInIdToken = true,
            },
        };
}