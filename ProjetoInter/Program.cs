using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore.Design;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ServiceDatabase>(options => options.UseSqlServer("Server=localhost; Database=dbrppiscinas; Trusted_Connection=True; TrustServerCertificate=True"));

builder.Services.AddHttpClient();
builder.Services.AddSession();

var app = builder.Build();
app.UseSession();

app.MapControllerRoute("default", "{controller=Index}/{action=Read}/{id?}");

app.Run();
