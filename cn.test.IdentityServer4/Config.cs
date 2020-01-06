using System;
using System.Collections;
using System.Collections.Generic;
using IdentityServer4.Models;
using IdentityServer4;
using IdentityServer4.Test;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using cn.test.IdentityServer4.Models;

namespace cn.test.IdentityApi
{
    public class Config
    {

        public static IEnumerable<ApiResource> GetApis()
        {
            return new List<ApiResource>
            {
                new ApiResource("api1", "My API")
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId="client",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = {
                        new Secret("secret".Sha256())
                    },
                    AllowedScopes={"api1"}
                },
                new Client
                {
                    ClientId="ro.client",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    ClientSecrets = {
                        new Secret("secret".Sha256())
                    },
                    AllowedScopes={"api1"}
                }
            };
        }

        public static IEnumerable<IdentityResource> GetResources()
        {
            return new List<IdentityResource>{
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };
        }

        public static List<TestUser> GetUsers(ServiceProvider provider)
        {
            var webAppIdentityDemoUser = provider.GetRequiredService<UserManager<WebAppIdentityDemoUser>>();
            IList<WebAppIdentityDemoUser> users = null;

            users = webAppIdentityDemoUser.GetUsersInRoleAsync("Administrator").Result;

            List<TestUser> testUsers = new List<TestUser>();
            foreach (var user in users)
            {
                testUsers.Add(new TestUser()
                {
                    SubjectId = user.Id.ToString(),
                    Username = user.UserName,
                    Password = user.PasswordHash
                });
            }
            return testUsers;
        }
    }
}
