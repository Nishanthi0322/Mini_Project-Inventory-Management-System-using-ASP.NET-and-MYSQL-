using Microsoft.EntityFrameworkCore;
using InventoryManagementSystem.Data;

var builder = WebApplication.CreateBuilder(args);

// connection string (edit if your MySQL uses a password/port)
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") 
                       ?? "server=localhost;database=inventory_db;uid=root;pwd=;";

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

// MVC services
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Ensure DB created (development convenience)
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    db.Database.EnsureCreated();
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Products}/{action=Index}/{id?}");

app.Run();
