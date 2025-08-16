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
                        new Claim(JwtClaimTypes.Id,"admin"),
                        new Claim(JwtClaimTypes.Name, "admin"),
                    }
                },
                new TestUser
                {
                    SubjectId = "1",
                    Username = "jay",
                    Password = password,
                    Claims =
                    {
                        new Claim(JwtClaimTypes.Id,"jay"),
                        new Claim(JwtClaimTypes.Name, "jay"),                   
                    }
                },
                new TestUser
                {
                    SubjectId = "2",
                    Username = "marty",
                    Password = password,
                    Claims =
                    {
                        new Claim(JwtClaimTypes.Id,"marty"),
                        new Claim(JwtClaimTypes.Name, "marty"),                       
                    }
                },
                new TestUser
                {
                    SubjectId = "3",
                    Username = "chris",
                    Password = password,
                    Claims =
                    {
                        new Claim(JwtClaimTypes.Id,"chris"),
                        new Claim(JwtClaimTypes.Name, "chris"),                      
                    }
                },
                new TestUser
                {
                    SubjectId = "4",
                    Username = "bill",
                    Password = password,
                    Claims =
                    {
                        new Claim(JwtClaimTypes.Id,"bill"),
                        new Claim(JwtClaimTypes.Name, "bill"),
                       
                    }
                }
                ,
                new TestUser
                {
                    SubjectId = "5",
                    Username = "allie",
                    Password = password,
                    Claims =
                    {
                        new Claim(JwtClaimTypes.Id,"allie"),
                        new Claim(JwtClaimTypes.Name, "allie"),
                    }
                },
                new TestUser
                {
                    SubjectId = "4",
                    Username = "allie",
                    Password = password,
                    Claims =
                    {
                        new Claim(JwtClaimTypes.Id,"allie"),
                        new Claim(JwtClaimTypes.Name, "allie"),
                    }
                }
            };
        }
    }
}