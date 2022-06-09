using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SpectacoleWeb.Data;
using SpectacoleWeb.Repository;
using SpectacoleWeb.Areas.Identity.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;
using SpectacoleWeb.Models;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("SpectacoleWebIdentityDbContextConnection") ?? throw new InvalidOperationException("Connection string 'SpectacoleWebIdentityDbContextConnection' not found.");

builder.Services.AddDbContext<SpectacoleWebIdentityDbContext>(options =>
    options.UseSqlServer(connectionString));;

builder.Services.AddDbContext<SpectacoleWebContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SpectacoleWebContext") ?? throw new InvalidOperationException("Connection string 'SpectacoleWebContext' not found.")));



DependencyInjection.AddRepository(builder.Services, builder.Configuration.GetConnectionString("SpectacoleWebContext"), connectionString);

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddRazorPages();

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<SpectacoleWebIdentityDbContext>()
    .AddDefaultUI()
    .AddDefaultTokenProviders();

builder.Services.AddAuthentication().AddGoogle(googleOptions =>
{
    googleOptions.ClientId = builder.Configuration["Authentication:Google:ClientId"];
    googleOptions.ClientSecret = builder.Configuration["Authentication:Google:ClientSecret"];
});

#region Authorization

AddAuthorizationPolicies(builder.Services);

#endregion

var app = builder.Build();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();



app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();

void AddAuthorizationPolicies(IServiceCollection services)
{
    services.AddAuthorization(options =>
    {
        options.AddPolicy("RequireAdmin", policy => policy.RequireRole("Administrator"));
        options.AddPolicy("RequireClient", policy => policy.RequireRole("Client"));
    });
}
