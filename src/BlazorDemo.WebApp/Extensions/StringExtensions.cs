// -------------------------------------------------------------------------------------
//  <copyright file="StringExtensions.cs" company="{Company Name}">
//    Copyright (c) {Company Name}. All rights reserved.
//  </copyright>
// -------------------------------------------------------------------------------------

namespace BlazorDemo.WebApp.Extensions;

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

public static class StringExtensions
{
    public static List<Claim> DecodeJwt(this string token)
    {
        var handler = new JwtSecurityTokenHandler();
        var jwtToken = handler.ReadJwtToken(token);
        var claims = new List<Claim>(jwtToken.Claims);

        return claims;
    }
}