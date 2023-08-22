using Business.DataAccess.Context;
using Business.DataAccess.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

#region IoC (Inversion of Control) Container: Bağımlıkların Yönetilmesi

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection"); // OnConfiguring yerine appsettinsteki connection stringi kullandık.
builder.Services.AddDbContext<Db>(options => options.UseSqlServer(connectionString, b => b.MigrationsAssembly("MVC")));


builder.Services.AddScoped<ProductServiceBase, ProductService>();
builder.Services.AddScoped<CategoryServiceBase, CategoryService>(); // Controllerlara enjekte edilen servislerin bağımlıkları

#endregion

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
