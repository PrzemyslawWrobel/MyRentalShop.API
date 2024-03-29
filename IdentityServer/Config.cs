﻿// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityModel;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace IdentityServer
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResource(name: "user1", userClaims: new[] {JwtClaimTypes.Email} )
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("api1"),  
                new ApiScope("Openid"),
            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                new Client
                {
                    ClientId = "client",
                    ClientName = "Client for Postman user",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPasswordAndClientCredentials,
                    //Podajemy hasło "" a potem szyfrujemy .Sha256()
                    ClientSecrets = { new Secret("secret".Sha256())},
                    //Definiujemy jakie resources i scopes będą dostępne przez tego klienta
                    AllowedScopes = { "api1", "user1"},
                    AlwaysIncludeUserClaimsInIdToken = true,
                    AllowAccessTokensViaBrowser = true,
                }, 

                new Client
                {
                    ClientId = "swagger",
                    ClientName = "Client for Swagger user",
                    AllowedGrantTypes = GrantTypes.CodeAndClientCredentials,
                    //Podajemy hasło "" a potem szyfrujemy .Sha256()
                    ClientSecrets = { new Secret("secret".Sha256())},
                    //Definiujemy jakie resources i scopes będą dostępne przez tego klienta
                    AllowedScopes = { "api1", "user1", "openid"},
                    AlwaysIncludeUserClaimsInIdToken = true,
                    AllowAccessTokensViaBrowser = true,
                    RedirectUris = { "https://localhost:44311/swagger/oauth2-redirect.html" },
                    AllowedCorsOrigins = {"https://localhost:44311"},
                }


                //// m2m client credentials flow client
                //new Client
                //{
                //    ClientId = "m2m.client",
                //    ClientName = "Client Credentials Client",

                //    AllowedGrantTypes = GrantTypes.ClientCredentials,
                //    ClientSecrets = { new Secret("511536EF-F270-4058-80CA-1C89C192F69A".Sha256()) },

                //    AllowedScopes = { "scope1" }
                //},

                //// interactive client using code flow + pkce
                //new Client
                //{
                //    ClientId = "interactive",
                //    ClientSecrets = { new Secret("49C1A7E1-0C79-4A89-A3D6-A37998FB86B0".Sha256()) },

                //    AllowedGrantTypes = GrantTypes.Code,

                //    RedirectUris = { "https://localhost:44300/signin-oidc" },
                //    FrontChannelLogoutUri = "https://localhost:44300/signout-oidc",
                //    PostLogoutRedirectUris = { "https://localhost:44300/signout-callback-oidc" },

                //    AllowOfflineAccess = true,
                //    AllowedScopes = { "openid", "profile", "scope2" }
                //},
            };
    }
}