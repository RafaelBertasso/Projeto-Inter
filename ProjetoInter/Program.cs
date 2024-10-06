using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore.Design;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ServiceDatabase>(options => options.UseSqlServer("Server=localhost; Database=dbservices; Trusted_Connection=True; TrustServerCertificate=True"));

var app = builder.Build();

app.MapControllerRoute("default", "{controller=User}/{action=Read}/{id?}");

app.Run();
