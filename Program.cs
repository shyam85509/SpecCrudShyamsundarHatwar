using Microsoft.EntityFrameworkCore;
using SpecCrudPro.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddControllersWithViews();

var connections = builder.Configuration.GetConnectionString("Constr");
builder.Services.AddDbContext<DatabaseContext>(
    options =>
    {
        options.UseSqlServer(connections);
    }
    );

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Crud}/{action=Register}/{id?}");

app.Run();
