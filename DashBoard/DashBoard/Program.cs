using DashBoard.Data;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<MySqlDbContext>(
    options => options.UseMySql(
            builder.Configuration.GetConnectionString("MySqlConnection"),
                             new MySqlServerVersion(new Version(8, 0, 28))
        )
);
builder.Services.AddDbContext<SqlServerDbContext>(
    options => options.UseSqlServer(
            builder.Configuration.GetConnectionString("SqlServerConnection")
        )
);
// Add services to the container.
builder.Services.AddControllersWithViews();

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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
