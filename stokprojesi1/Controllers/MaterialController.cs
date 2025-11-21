using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using stokprojesi1.Data;
using stokprojesi1.Models;

namespace stokprojesi1.Controllers
{
    [Authorize] // Giriş yapmadan erişilemesin
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
            var materials = await _context.Materials
                .Include(m => m.Category)
                .ToListAsync();
            return View(materials);
        }

        // 2. EKLEME EKRANI (Create - GET)
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "Name");
            return View();
        }

        // 3. EKLEME İŞLEMİ (Create - POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Material material)
        {
            if (ModelState.IsValid)
            {
                _context.Add(material);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "Name", material.CategoryId);
            return View(material);
        }

        // 4. GÜNCELLEME SAYFASI (Edit - GET)
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) 
                return NotFound();

            var material = await _context.Materials.FindAsync(id);
            if (material == null) 
                return NotFound();

            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "Name", material.CategoryId);
            return View(material);
        }

        // 5. GÜNCELLEME İŞLEMİ (Edit - POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Material material)
        {
            if (id != material.MaterialId) 
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(material);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Materials.Any(e => e.MaterialId == material.MaterialId))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }
            
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "Name", material.CategoryId);
            return View(material);
        }

        // 6. SİLME İŞLEMİ
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