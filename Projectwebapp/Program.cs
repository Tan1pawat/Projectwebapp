using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.AspNetCore.Session;
using Microsoft.EntityFrameworkCore;
using Projectwebapp.Data;
using Microsoft.AspNetCore.Authentication.Cookies;//new
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme) //new
    .AddCookie(option => //new
    {
        option.LoginPath = "/User/Index";
        option.ExpireTimeSpan = TimeSpan.FromMinutes(20);
    }); //new
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
});

builder.Services.AddHttpContextAccessor();
builder.Services.AddDbContext<ApplicationDBcontext>(
    Options => Options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
    );
builder.Services.AddDbContext<ProductDBcontext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("ProductDBConnection"))
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

app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=User}/{action=Index}/{id?}");

app.Run();
