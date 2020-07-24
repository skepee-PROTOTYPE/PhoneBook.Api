// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace MyIdentityServer
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };

        //public static IEnumerable<ApiScope> ApiScopes =>
        //     //new ApiScope[]
        //     //{           

        //     //};
        //new List<ApiScope>
        //{
        //    new ApiScope(name: "read", displayName: "Read your data."),
        //    new ApiScope(name: "write", displayName: "Write your data."),
        //    new ApiScope(name: "delete", displayName: "Delete your data.")
        //};

        public static IEnumerable<Client> Clients =>
                new Client[]
                {
                new Client
                {
                    ClientName="Phone Book",
                    ClientId="phonebookclient",
                    AllowedGrantTypes=GrantTypes.Code,
                    RequirePkce = true,
                    RedirectUris= new List<string>()
                    {
                        "https://localhost:44361/signin-oidc"
                    },
                    PostLogoutRedirectUris = new List<string>()
                    {
                        "https://localhost:44361/signout-callback-oidc"
                    },
                    AllowedScopes=
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "phonebookapi"
                    },
                    ClientSecrets=
                    {
                        new Secret("miosecret".Sha256())
                    }
                }
                };
    }
}