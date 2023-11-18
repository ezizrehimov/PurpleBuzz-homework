using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PurpleBuzz_homework.DAL;
using PurpleBuzz_homework.Helpers;
using PurpleBuzz_homework.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<IFileService, FileService>();

var connectionSting = builder.Configuration.GetConnectionString("ConString");

builder.Services.AddDbContext<AppDbContext>(x => x.UseSqlServer(connectionSting));
builder.Services.AddIdentity<User, IdentityRole>(option =>
{
    option.Password.RequiredLength = 8;
    option.Password.RequireNonAlphanumeric = true;
    option.Password.RequiredUniqueChars = 1;
    option.Password.RequireDigit = true;
    option.Password.RequireUppercase = true;
    option.Password.RequireLowercase = true;
    option.User.RequireUniqueEmail = true;
    option.Lockout.MaxFailedAccessAttempts = 3;
}).AddEntityFrameworkStores<AppDbContext>();

var app = builder.Build();
app.UseStaticFiles();

app.MapControllerRoute(
    name: "admin",
    pattern: "{area}/{controller=dashboard}/{action=index}/{id?}"
    );

app.MapControllerRoute(
     name: "default",
     pattern: "{controller=home}/{action=index}/{id?}"
     );


app.Run();
