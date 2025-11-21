using Microsoft.EntityFrameworkCore;
using stokprojesi1.Data; // Senin DbContext'in burada
using stokprojesi1.Models;

var builder = WebApplication.CreateBuilder(args);

// 1. MVC Servisini Ekliyoruz (Hoca MVC istemişti)
builder.Services.AddControllersWithViews();

// 2. Veritabanı Bağlantısını Ekliyoruz (SQL Server Ayarı)
// Not: Connection string adının "DefaultConnection" olduğundan emin olacağız.
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Hata yönetimi ve Güvenlik ayarları (Standart kalıp)
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles(); // CSS, JS dosyaları çalışsın diye

app.UseRouting();

app.UseAuthorization(); // Hoca yetkilendirme istemişti, bu dursun

// 3. Rota Ayarı (Site açılınca hangi sayfaya gitsin?)
// Açılınca "Home" controller'ındaki "Index" sayfasına gider.
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();