using System.Net;
using coin_keeper_clone_backend;
using CoinKeeper.DataAccess.Database;
using CoinKeeper.DataAccess.Infrastructure;
using CoinKeeper.DataAccess.Repositories;
using CoinKeeper.Services.Currency;
using Domain.Entities.Roles;
using Domain.Entities.Users;
using Domain.Repositories;
using Domain.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHealthChecks();
builder.Services.AddCors();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
    {
        options.Events.OnRedirectToAccessDenied = StartupUtils.ReplaceRedirector(HttpStatusCode.Forbidden, options.Events.OnRedirectToAccessDenied);
        options.Events.OnRedirectToLogin = StartupUtils.ReplaceRedirector(HttpStatusCode.Unauthorized, options.Events.OnRedirectToLogin);
    });

builder.Services.Configure<ForwardedHeadersOptions>(options =>
{
    options.ForwardedHeaders =
        ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
});

builder.Services.AddIdentityCore<User>()
    .AddRoles<Role>();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();

builder.Services.AddScoped<IUserStore<User>, UserStore>();
builder.Services.AddScoped<IRoleStore<Role>, RoleStore>();

// Services identity depends on
builder.Services.AddOptions().AddLogging();

// Services used by identity
builder.Services.TryAddScoped<IUserValidator<User>, UserValidator<User>>();
builder.Services.TryAddScoped<IPasswordValidator<User>, PasswordValidator<User>>();
builder.Services.TryAddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
builder.Services.TryAddScoped<ILookupNormalizer, UpperInvariantLookupNormalizer>();
// No interface for the error describer so we can add errors without rev'ing the interface
builder.Services.TryAddScoped<IdentityErrorDescriber>();
builder.Services.TryAddScoped<IUserClaimsPrincipalFactory<User>, UserClaimsPrincipalFactory<User>>();
builder.Services.TryAddScoped<UserManager<User>, UserManager<User>>();
builder.Services.TryAddScoped<RoleManager<Role>, RoleManager<Role>>();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"), optionsBuilder =>
    {
        optionsBuilder.MigrationsAssembly("CoinKeeper.Api");
    });
});

builder.Services.AddScoped<ICurrencyService, CurrencyService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseHsts();    
}

app.UseForwardedHeaders();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseRouting();
app.UseCors(corsPolicyBuilder =>
{
    corsPolicyBuilder.WithOrigins("https://localhost:44453", "https://coinkeeperclone.com");
    corsPolicyBuilder.AllowAnyHeader();
    corsPolicyBuilder.AllowAnyMethod();
    corsPolicyBuilder.AllowCredentials();
});
app.UseAuthorization();
app.UseDefaultFiles();
app.UseStaticFiles();
app.MapControllers();
app.MapHealthChecks("/health");
app.MapFallbackToFile("index.html");

app.Run();