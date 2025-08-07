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
            string password = "f"; // Password for admin user

            return new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = "0",
                    Username = "admin",
                    Password = password,
                    Claims =
                    {
                        //These claim names must be in the list of  claims_supported 
                        // .well-known/openid-configuration
                        new Claim(JwtClaimTypes.Id,"admin"),
                        new Claim(JwtClaimTypes.Name, "admin"),
                        new Claim(JwtClaimTypes.Role, "admin"),

                        new Claim(JwtClaimTypes.GivenName, "ADMINISTRATOR"),
                        new Claim(JwtClaimTypes.FamilyName, "ADMINISTRATOR"),
                        new Claim(JwtClaimTypes.Email, "email@gmail.com"),
                        new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
                        new Claim(JwtClaimTypes.WebSite, "http://thanh.com"),
                        new Claim(JwtClaimTypes.Address, JsonSerializer.Serialize(address), IdentityServerConstants.ClaimValueTypes.Json),
                       
                    }
                },
                new TestUser
                {
                    SubjectId = "1",
                    Username = "reviewer",
                    Password = password,
                    Claims =
                    {
                        new Claim(JwtClaimTypes.Id,"reviewer"),
                        new Claim(JwtClaimTypes.Name, "reviewer"),
                        new Claim(JwtClaimTypes.Role, "reviewer"),

                        new Claim(JwtClaimTypes.Name, "Alice Smith"),
                        new Claim(JwtClaimTypes.GivenName, "Alice"),
                        new Claim(JwtClaimTypes.FamilyName, "Smith"),
                        new Claim(JwtClaimTypes.Email, "AliceSmith@email.com"),
                        new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
                        new Claim(JwtClaimTypes.WebSite, "http://alice.com"),
                        new Claim(JwtClaimTypes.Address, JsonSerializer.Serialize(address), IdentityServerConstants.ClaimValueTypes.Json),
                        new Claim(JwtClaimTypes.Role, "reviewer"),
                    }
                },
                new TestUser
                {
                    SubjectId = "2",
                    Username = "reviewersup",
                    Password = password,
                    Claims =
                    {
                        new Claim(JwtClaimTypes.Id,"reviewersup"),
                        new Claim(JwtClaimTypes.Name, "reviewersup"),
                        new Claim(JwtClaimTypes.Role, "reviewersup"),

                        new Claim(JwtClaimTypes.Name, "Alice Smith"),
                        new Claim(JwtClaimTypes.GivenName, "Alice"),
                        new Claim(JwtClaimTypes.FamilyName, "Smith"),
                        new Claim(JwtClaimTypes.Email, "AliceSmith@email.com"),
                        new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
                        new Claim(JwtClaimTypes.WebSite, "http://alice.com"),
                        new Claim(JwtClaimTypes.Address, JsonSerializer.Serialize(address), IdentityServerConstants.ClaimValueTypes.Json),
                        new Claim(JwtClaimTypes.Role, "reviewer"),
                    }
                },
                new TestUser
                {
                    SubjectId = "3",
                    Username = "worker",
                    Password = password,
                    Claims =
                    {
                        new Claim(JwtClaimTypes.Id,"worker"),
                        new Claim(JwtClaimTypes.Name, "worker"),
                        new Claim(JwtClaimTypes.Role, "worker"),

                        new Claim(JwtClaimTypes.Name, "Alice Smith"),
                        new Claim(JwtClaimTypes.GivenName, "Alice"),
                        new Claim(JwtClaimTypes.FamilyName, "Smith"),
                        new Claim(JwtClaimTypes.Email, "AliceSmith@email.com"),
                        new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
                        new Claim(JwtClaimTypes.WebSite, "http://alice.com"),
                        new Claim(JwtClaimTypes.Address, JsonSerializer.Serialize(address), IdentityServerConstants.ClaimValueTypes.Json),
                        new Claim(JwtClaimTypes.Role, "worker"),
                    }
                },
                new TestUser
                {
                    SubjectId = "4",
                    Username = "workersup",
                    Password = password,
                    Claims =
                    {
                        new Claim(JwtClaimTypes.Id,"workersup"),
                        new Claim(JwtClaimTypes.Name, "workersup"),
                        new Claim(JwtClaimTypes.Role, "workersup"),

                        new Claim(JwtClaimTypes.Name, "Bob Smith"),
                        new Claim(JwtClaimTypes.GivenName, "Bob"),
                        new Claim(JwtClaimTypes.FamilyName, "Smith"),
                        new Claim(JwtClaimTypes.Email, "BobSmith@email.com"),
                        new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
                        new Claim(JwtClaimTypes.WebSite, "http://bob.com"),
                        new Claim(JwtClaimTypes.Address, JsonSerializer.Serialize(address), IdentityServerConstants.ClaimValueTypes.Json),
                    }
                }
                ,
                new TestUser
                {
                    SubjectId = "5",
                    Username = "assigned",
                    Password = password,
                    Claims =
                    {
                        new Claim(JwtClaimTypes.Id,"assigned"),
                        new Claim(JwtClaimTypes.Name, "assigned"),
                        new Claim(JwtClaimTypes.Role, "assigned"),

                        new Claim(JwtClaimTypes.Name, "Alice Smith"),
                        new Claim(JwtClaimTypes.GivenName, "Alice"),
                        new Claim(JwtClaimTypes.FamilyName, "Smith"),
                        new Claim(JwtClaimTypes.Email, "AliceSmith@email.com"),
                        new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
                        new Claim(JwtClaimTypes.WebSite, "http://alice.com"),
                        new Claim(JwtClaimTypes.Address, JsonSerializer.Serialize(address), IdentityServerConstants.ClaimValueTypes.Json),
                        new Claim(JwtClaimTypes.Role, "worker"),
                    }
                },
                new TestUser
                {
                    SubjectId = "4",
                    Username = "assignedsup",
                    Password = password,
                    Claims =
                    {
                        new Claim(JwtClaimTypes.Id,"assignedsup"),
                        new Claim(JwtClaimTypes.Name, "assignedsup"),
                        new Claim(JwtClaimTypes.Role, "assignedsup"),

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