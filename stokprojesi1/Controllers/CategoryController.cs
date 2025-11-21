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
        private readonly AppDbContext _context;

        public CategoryController(AppDbContext context)
        {
            _context = context;
        }

        // 1. LİSTELEME SAYFASI (Index)
        public async Task<IActionResult> Index()
        {
            var categories = await _context.Categories.ToListAsync();
            return View(categories);
        }

        // 2. EKLEME SAYFASI - GÖRÜNÜM (Create - GET)
        public IActionResult Create()
        {
            return View();
        }

        // 3. EKLEME İŞLEMİ - KAYDETME (Create - POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category category)
        {
            if (ModelState.IsValid)
            {
                _context.Add(category);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }
        
        // 4. SİLME İŞLEMİ
        public async Task<IActionResult> Delete(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category != null)
            {
                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}