﻿using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.IdentityModel.Tokens;
using OJBlazor.Share.DataModels;

namespace OJBlazor.WebApi;

public class JwtHelper
{
    private readonly IConfiguration _configuration;

    public JwtHelper(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    public string GetMemberToken(UserModel model)
    {
        var claims = new Claim[]
        {
            new(ClaimTypes.Name, model.Name),
            new(ClaimTypes.NameIdentifier, model.Id)
        };

        var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]!));
        const string algorithm = SecurityAlgorithms.HmacSha256;
        var signingCredentials = new SigningCredentials(secretKey, algorithm);

        var securityToken = new JwtSecurityToken(
            claims: claims,
            notBefore: DateTime.Now, //notBefore
            expires: DateTime.Now.AddSeconds(30), //expires
            signingCredentials: signingCredentials
        );
        var token = new JwtSecurityTokenHandler().WriteToken(securityToken);
        return token;
    }
}

public class TokenActionFilter : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        var bearer = context.HttpContext.Request.Headers["Authorization"].FirstOrDefault();
        if (string.IsNullOrEmpty(bearer) || !bearer.Contains("Bearer")) return;
        var jwt = bearer.Split(' ');
        var tokenObj = new JwtSecurityToken(jwt[1]);

        var claimsIdentity = new ClaimsIdentity(tokenObj.Claims);
        var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
        context.HttpContext.User = claimsPrincipal;
    }
}

public static class TokenHelper
{
    public static UserModel? GetUser(this ClaimsPrincipal claims)
    {
        if (claims.Identity is null || !claims.Identity.IsAuthenticated) return default;
        var name = claims.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name)?.Value;
        var id = claims.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
        if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(id)) return default;
        return new UserModel() { Name = name, Id = id };
    }
}