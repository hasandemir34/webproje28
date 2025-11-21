using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering; // Dropdown için gerekli
using Microsoft.EntityFrameworkCore;
using stokprojesi1.Data;
using stokprojesi1.Models;

namespace stokprojesi1.Controllers
{
    public class MaterialController : Controller
    {
        private readonly AppDbContext _context;

        public MaterialController(AppDbContext context)
        {
            _context = context;
        }

        // 1. LİSTELEME (Kategorisiyle beraber getirir)
        public async Task<IActionResult> Index()
        {
            // Include komutu "Git malzemeyi alırken Kategori tablosuna da bak, adını getir" demek.
            var materials = await _context.Materials.Include(m => m.Category).ToListAsync();
            return View(materials);
        }

        // 2. EKLEME EKRANI (Create - GET)
        public IActionResult Create()
        {
            // İşte Puan Kazandıran Yer: ViewBag
            // Kategorileri veritabanından çekip kutuya dolduruyoruz.
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "Name");
            return View();
        }

        // 3. EKLEME İŞLEMİ (Create - POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Material material)
        {
            // Validation kontrolünü biraz gevşettik, direkt ekliyoruz
            if (ModelState.IsValid)
            {
                _context.Add(material);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            
            // Hata olursa kutuyu tekrar doldur ki boş gelmesin
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "Name", material.CategoryId);
            return View(material);
        }

        // SİLME İŞLEMİ
        public async Task<IActionResult> Delete(int id)
        {
            var material = await _context.Materials.FindAsync(id);
            if (material != null)
            {
                _context.Materials.Remove(material);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}