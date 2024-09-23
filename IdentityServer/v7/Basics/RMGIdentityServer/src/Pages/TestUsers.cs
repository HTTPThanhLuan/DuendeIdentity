using IdentityModel;
using Microsoft.AspNetCore.Identity;
using RMG.IdentityServer;
using RMG.IdentityServer.Test;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text.Json;


namespace IdentityServerHost;

public class TestUsers
{
    public static List<TestUser> Users
    {
        get
        {
            var address = new
            {
                street_address = "1100 E Church",
                locality = "Pierre",
                postal_code = "57501",
                country = "USA"
            };
                
            return new List<TestUser>
            {
                 new TestUser
                {
                    SubjectId = "0",
                    Username = "admin",
                    Password = "Rushmore321!",
                    Claims =
                    {
                        //These claim names must be in the list of  claims_supported 
                        // .well-known/openid-configuration
                        new Claim(JwtClaimTypes.Name, "Thanh Tran"),
                        new Claim(JwtClaimTypes.GivenName, "Thanh"),
                        new Claim(JwtClaimTypes.FamilyName, "Luan"),
                        new Claim(JwtClaimTypes.Email, "thanh.tran@rushmore-group.com.com"),
                        new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
                        new Claim(JwtClaimTypes.WebSite, "http://thanh.com"),
                        new Claim(JwtClaimTypes.Address, JsonSerializer.Serialize(address), IdentityServerConstants.ClaimValueTypes.Json),
                        new Claim(JwtClaimTypes.PreferredUserName,"admin")
                    }
                },
                new TestUser
                {
                    SubjectId = "1",
                    Username = "alice",
                    Password = "alice",
                    Claims =
                    {
                        new Claim(JwtClaimTypes.Name, "Alice Smith"),
                        new Claim(JwtClaimTypes.GivenName, "Alice"),
                        new Claim(JwtClaimTypes.FamilyName, "Smith"),
                        new Claim(JwtClaimTypes.Email, "AliceSmith@email.com"),
                        new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
                        new Claim(JwtClaimTypes.WebSite, "http://alice.com"),
                        new Claim(JwtClaimTypes.Address, JsonSerializer.Serialize(address), IdentityServerConstants.ClaimValueTypes.Json)
                    }
                },
                new TestUser
                {
                    SubjectId = "2",
                    Username = "bob",
                    Password = "bob",
                    Claims =
                    {
                        new Claim(JwtClaimTypes.Name, "Bob Smith"),
                        new Claim(JwtClaimTypes.GivenName, "Bob"),
                        new Claim(JwtClaimTypes.FamilyName, "Smith"),
                        new Claim(JwtClaimTypes.Email, "BobSmith@email.com"),
                        new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
                        new Claim(JwtClaimTypes.WebSite, "http://bob.com"),
                        new Claim(JwtClaimTypes.Address, JsonSerializer.Serialize(address), IdentityServerConstants.ClaimValueTypes.Json)
                    }
                }
            };
        }
    }
}