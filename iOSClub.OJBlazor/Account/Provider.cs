using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using OJBlazor.Share.DataModels;

namespace iOSClub.OJBlazor;

public class Provider : AuthenticationStateProvider
{
    private readonly ProtectedSessionStorage _sessionStorage;
    private readonly ClaimsPrincipal _anonymous = new(new ClaimsIdentity());

    public Provider(ProtectedSessionStorage sessionStorage)
    {
        _sessionStorage = sessionStorage;
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        try
        {
            var storageResult = await _sessionStorage.GetAsync<UserModel>("Permission");
            var model = storageResult.Success ? storageResult.Value : null;
            if (model == null)
            {
                return await Task.FromResult(new AuthenticationState(_anonymous));
            }

            var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
            {
                new(ClaimTypes.Name, model.Name),
                new(ClaimTypes.NameIdentifier, model.Id),
                new(ClaimTypes.Role,model.Identity)
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
            await _sessionStorage.SetAsync("Permission", model);
            claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
            {
                new(ClaimTypes.Name, model.Name),
                new(ClaimTypes.NameIdentifier, model.Id),
                new(ClaimTypes.Role,model.Identity)
            }));
        }
        else
        {
            await _sessionStorage.DeleteAsync("Permission");
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
        var id = claims.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
        var auth = claims.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value;
        if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(id) || string.IsNullOrEmpty(auth)) return default;
        return new UserModel() { Name = name, Id = id,Identity = auth};
    }
}