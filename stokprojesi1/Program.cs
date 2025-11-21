using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity; // YENİ
using stokprojesi1.Data;
using stokprojesi1.Models;

var builder = WebApplication.CreateBuilder(args);

// 1. MVC Servisi
builder.Services.AddControllersWithViews();

// 2. Veritabanı Bağlantısı
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// 3. IDENTITY (ÜYELİK) SERVİSİ - YENİ EKLENDİ
// Şifre kurallarını test kolay olsun diye basitleştirdik (3 karakter yeterli)
builder.Services.AddIdentity<IdentityUser, IdentityRole>(options => {
    options.Password.RequireDigit = false;
    options.Password.RequiredLength = 3;
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

// 4. GÜVENLİK SIRALAMASI ÖNEMLİDİR (Önce Authentication, Sonra Authorization)
app.UseAuthentication(); // YENİ: Kimsin sen?
app.UseAuthorization();  // Yetkin var mı?

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();