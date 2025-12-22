using Microsoft.AspNetCore.Identity.EntityFrameworkCore; // YENİ
using Microsoft.EntityFrameworkCore;
using stokprojesi1.Models;

namespace stokprojesi1.Data
{
    // DbContext yerine IdentityDbContext'ten miras alıyoruz
    public class AppDbContext : IdentityDbContext //korumalı database derim
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; } //kategoriler tablosu
        public DbSet<Material> Materials { get; set; } //materyaller tablosu
    }   //tablo içinde gereken bilgiler de tutulur. bu sayede kalıcı olarak saklıyoruz.
}