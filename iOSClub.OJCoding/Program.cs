using System.Text;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using iOSClub.OJCoding.Account;
using iOSClub.OJCoding.CodeRun;
using iOSClub.OJCoding.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.WebEncoders;
using OJCoding.Share.DataModels;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddBootstrapBlazor();
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<ProtectedSessionStorage>();
builder.Services.AddScoped<DockerHelper>();
builder.Services.AddScoped<AuthenticationStateProvider, Provider>();
builder.Services.AddOptions();
builder.Services.AddAuthorizationCore();
builder.Services.AddAuthentication();

builder.Services.Configure<HubOptions>(option => option.MaximumReceiveMessageSize = null);

Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

if (builder.Environment.IsDevelopment())
{
    builder.Services.AddDbContextFactory<OJContext>(opt =>
        opt.UseSqlite(configuration.GetConnectionString("SQLite")));
}
else if (builder.Environment.IsProduction())
{
    builder.Services.AddDbContextFactory<OJContext>(opt =>
        opt.UseMySQL(configuration.GetConnectionString("MySQL")!));
}

builder.Services.Configure<WebEncoderOptions>(options =>
    options.TextEncoderSettings = new TextEncoderSettings(UnicodeRanges.All));

var app = builder.Build();
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<OJContext>();
    try
    {
        context.Database.Migrate();
        context.Database.EnsureCreated();
    }
    catch
    {
        var databaseCreator = (RelationalDatabaseCreator)context.Database.GetService<IDatabaseCreator>();
        databaseCreator.CreateTables();
        context.Database.Migrate();
    }

    context.SaveChanges();
    context.Dispose();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();