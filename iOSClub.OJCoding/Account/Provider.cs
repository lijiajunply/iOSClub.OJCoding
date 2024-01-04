﻿using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using OJCoding.Share.DataModels;

namespace iOSClub.OJCoding.Account;

public class Provider(ProtectedSessionStorage sessionStorage) : AuthenticationStateProvider
{
    private readonly ClaimsPrincipal _anonymous = new(new ClaimsIdentity());

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        try
        {
            var storageResult = await sessionStorage.GetAsync<UserModel>("Permission");
            var model = storageResult.Success ? storageResult.Value : null;
            if (model == null)
            {
                return await Task.FromResult(new AuthenticationState(_anonymous));
            }

            var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
            {
                new(ClaimTypes.Name, model.Name),
                new(ClaimTypes.NameIdentifier, model.Password)
            }, "Auth"));

            return await Task.FromResult(new AuthenticationState(claimsPrincipal));
        }
        catch
        {
            return await Task.FromResult(new AuthenticationState(_anonymous));
        }
    }

    public async Task UpdateAuthState(UserModel? model)
    {
        ClaimsPrincipal claimsPrincipal;
        if (model is not null)
        {
            await sessionStorage.SetAsync("Permission", model);
            claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
            {
                new(ClaimTypes.Name, model.Name),
                new(ClaimTypes.NameIdentifier, model.Password)
            }));
        }
        else
        {
            await sessionStorage.DeleteAsync("Permission");
            claimsPrincipal = _anonymous;
        }

        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));
    }
}

public static class ProviderStatic
{
    public static UserModel? ToUser(this ClaimsPrincipal claims)
    {
        if (claims.Identity is null || !claims.Identity.IsAuthenticated) return default;
        var name = claims.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name)?.Value;
        var password = claims.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
        if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(password)) return default;
        return new UserModel() { Name = name, Password = password };
    }
}