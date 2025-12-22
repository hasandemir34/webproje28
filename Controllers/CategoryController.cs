using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using stokprojesi1.Data;
using stokprojesi1.Models;

namespace stokprojesi1.Controllers
{
    [Authorize] // Giriş yapmadan erişilemesin
    public class CategoryController : Controller
    {
        private readonly AppDbContext _context; //veri tabanı ile iletişim yapılıyor.

        public CategoryController(AppDbContext context) //çalışma ile birlikte hemen veritabanına bağlantıyı kurar
        {
            _context = context;
        }

        //listeleme
        public async Task<IActionResult> Index()
        {
            var categories = await _context.Categories.ToListAsync();
            return View(categories);
        }

        // ekleme kısmı boş bir form açıyor (get)
        public IActionResult Create()
        {
            return View();
        }

        //  KAYDETME (Create - POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category category)
        {
            if (ModelState.IsValid) //model için istenenler doğrumu kontrolü yapılır
            {
                _context.Add(category);
                await _context.SaveChangesAsync(); //kalıcı olarak değişiklikleri kaydet
                return RedirectToAction(nameof(Index));//işlem bitince indexe geri gel
            }
            return View(category);
        }
        
        //  SİLME
        public async Task<IActionResult> Delete(int id) //silinecek kısmın idsi alındı
        {
            var category = await _context.Categories.FindAsync(id);//bu id deki categoriyi bul
            if (category != null)
            {
                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();//ve yine kayıt yapıldı
            }
            return RedirectToAction(nameof(Index));
        }
    }
}