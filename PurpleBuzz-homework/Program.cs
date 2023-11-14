using Microsoft.EntityFrameworkCore;
using PurpleBuzz_homework.DAL;
using PurpleBuzz_homework.Helpers;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<IFileService, FileService>();

var connectionSting = builder.Configuration.GetConnectionString("ConString");

builder.Services.AddDbContext<AppDbContext>(x => x.UseSqlServer(connectionSting));

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
