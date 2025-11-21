using Microsoft.AspNetCore.Identity.EntityFrameworkCore; // YENİ
using Microsoft.EntityFrameworkCore;
using stokprojesi1.Models;

namespace stokprojesi1.Data
{
    // DbContext yerine IdentityDbContext'ten miras alıyoruz
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Material> Materials { get; set; }
    }
}