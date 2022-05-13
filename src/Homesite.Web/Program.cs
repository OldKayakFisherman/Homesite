using Homesite.Infrastructure.Persistence;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Homesite.Application.Common.Interfaces.Persistence;
using Homesite.Application.Common.Interfaces.Services.Logging;
using Homesite.Application.Common.Interfaces.Services.Parameters.Logging;
using Homesite.Application.Common.Interfaces.Services.Persistence;
using Homesite.Application.Common.Interfaces.Services.Process;
using Homesite.Application.Common.Interfaces.Services.Web;
using Homesite.Infrastructure.Identity;
using Homesite.Infrastructure.Middleware;
using Homesite.Infrastructure.Services.Logging;
using Homesite.Infrastructure.Services.Persistence;
using Homesite.Infrastructure.Services.Process;
using Homesite.Infrastructure.Services.Web;


var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(connectionString));;

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<ApplicationDbContext>();;

// Add services to the container.

builder.Services.AddDbContext<IApplicationDbContext,ApplicationDbContext>(options =>
    options.UseSqlite(connectionString)
);
builder.Services.AddDatabaseDeveloperPageExceptionFilter();


builder.Services.AddControllersWithViews();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Custom services 
builder.Services.AddTransient<IProjectParserService, ProjectParserService>();
builder.Services.AddTransient<IProjectImportService, ProjectImportService>();
builder.Services.AddTransient<ITrafficLoggerService, TrafficLoggerService>();
builder.Services.AddTransient<IUploadUtilityService, UploadUtilityService>();
builder.Services.AddTransient<IProjectDataService, ProjectDataService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseTrafficLoggerMiddleware();
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
