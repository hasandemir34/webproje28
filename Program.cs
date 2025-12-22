using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity; //hash denilen saklama methodu varmış
using stokprojesi1.Data;
using stokprojesi1.Models;

var builder = WebApplication.CreateBuilder(args);

// 1. MVC Servisi
builder.Services.AddControllersWithViews();

// 2. Veritabanı Bağlantısı
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<IdentityUser, IdentityRole>(options => { //kullanıcı şifre kısıtlamaları
    options.Password.RequireDigit = false;
    options.Password.RequiredLength = 5; //5 karakter lazım minimum
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
})
.AddEntityFrameworkStores<AppDbContext>()
.AddDefaultTokenProviders();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();


app.UseAuthentication(); 
app.UseAuthorization();  

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();