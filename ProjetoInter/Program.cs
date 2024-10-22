using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore.Design;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ServiceDatabase>(options => options.UseSqlServer("Server=localhost; Database=dbservices; Trusted_Connection=True; TrustServerCertificate=True"));

builder.Services.AddSession();

var app = builder.Build();
app.UseSession();

app.MapControllerRoute("default", "{controller=Menu}/{action=Read}/{id?}");

app.Run();
