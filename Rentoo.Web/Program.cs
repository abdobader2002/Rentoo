using System.Globalization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Rentoo.Application.Interfaces;
using Rentoo.Application.Services;
using Rentoo.Domain.Entities;
using Rentoo.Domain.Interfaces;
using Rentoo.Domain.Shared;
using Rentoo.Infrastructure.Data;
using Rentoo.Infrastructure.Repositories;
using Rentoo.Infrastructure.Seed; 




var builder = WebApplication.CreateBuilder(args);

#region 1️⃣ MVC & Localization Configuration

    builder.Services.AddControllersWithViews()
        .AddViewLocalization()
        .AddDataAnnotationsLocalization();

#endregion

#region  Database Configuration

builder.Services.AddDbContext<RentooDbContext>(options =>options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

#endregion

#region  Localization (Cultures)

var cultureConfiguration = builder.Configuration
    .GetSection(nameof(CultureConfiguration))
    .Get<CultureConfiguration>();

builder.Services.Configure<RequestLocalizationOptions>(opts =>
{
    var supportedCultureCodes = (cultureConfiguration?.Cultures?.Count > 0
        ? cultureConfiguration.Cultures.Intersect(CultureConfiguration.AvailableCultures)
        : CultureConfiguration.AvailableCultures).ToArray();

    if (!supportedCultureCodes.Any())
        supportedCultureCodes = CultureConfiguration.AvailableCultures;

    var supportedCultures = supportedCultureCodes.Select(c => new CultureInfo(c)).ToList();

    var defaultCultureCode = string.IsNullOrEmpty(cultureConfiguration?.DefaultCulture)
        ? CultureConfiguration.DefaultRequestCulture
        : cultureConfiguration.DefaultCulture;

    if (!supportedCultureCodes.Contains(defaultCultureCode))
        defaultCultureCode = supportedCultureCodes.FirstOrDefault();

    opts.DefaultRequestCulture = new RequestCulture(defaultCultureCode);
    opts.SupportedCultures = supportedCultures;
    opts.SupportedUICultures = supportedCultures;
    opts.RequestCultureProviders = new List<IRequestCultureProvider>
    {
        new QueryStringRequestCultureProvider(),
        new CookieRequestCultureProvider()
    };
});

#endregion

#region  Identity Configuration

builder.Services.AddIdentity<User, IdentityRole>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredLength = 1;
    options.Lockout.MaxFailedAccessAttempts = 10;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(15);
})
.AddEntityFrameworkStores<RentooDbContext>()
.AddDefaultTokenProviders();

#endregion

#region  Dependency Injection

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped(typeof(IService<>), typeof(Service<>));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

#endregion

var app = builder.Build();
#region  Seed Default Admin
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var userManager = services.GetRequiredService<UserManager<User>>();
    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
    await IdentitySeeder.SeedAsync(userManager, roleManager);
}
#endregion

#region  Middleware Pipeline

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication(); 
app.UseAuthorization();

app.UseRequestLocalization(app.Services
    .GetRequiredService<IOptions<RequestLocalizationOptions>>().Value);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

#endregion

app.Run();
