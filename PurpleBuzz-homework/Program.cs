using Microsoft.EntityFrameworkCore;
using PurpleBuzz_homework.DAL;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

var connectionSting = builder.Configuration.GetConnectionString("ConString");

builder.Services.AddDbContext<AppDbContext>(x => x.UseSqlServer(connectionSting));

var app = builder.Build();
app.UseStaticFiles();

app.MapControllerRoute(
    name: "admin",
    pattern: "{area=exists}/{controller=dashboard}/{action=index}/{id?}"
    );

app.MapControllerRoute(
     name: "default",
     pattern: "{controller=home}/{action=index}/{id?}"
     );


app.Run();
