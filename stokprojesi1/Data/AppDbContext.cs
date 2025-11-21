using Microsoft.EntityFrameworkCore;
using stokprojesi1.Models; // Senin proje adın neyse onu yaz

namespace stokprojesi1.Data
{
    // DbContext'ten miras alıyoruz ki EF Core özellikleri gelsin
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // İşte büyü burada: Bu satırlar tabloları oluşturacak
        public DbSet<Category> Categories { get; set; }
        public DbSet<Material> Materials { get; set; }
    }
}