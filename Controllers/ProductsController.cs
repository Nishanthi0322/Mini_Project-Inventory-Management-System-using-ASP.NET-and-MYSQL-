using InventoryManagementSystem.Data;
using InventoryManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagementSystem.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ProductsController(ApplicationDbContext context) => _context = context;

        public async Task<IActionResult> Index()
        {
            var list = await _context.Products.ToListAsync();
            return View(list);
        }

        public IActionResult Create() => View(new Product());

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product)
        {
            if (!ModelState.IsValid) return View(product);
            _context.Add(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var p = await _context.Products.FindAsync(id);
            return p == null ? NotFound() : View(p);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Product product)
        {
            if (id != product.Id) return NotFound();
            if (!ModelState.IsValid) return View(product);
            _context.Update(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var p = await _context.Products.FindAsync(id);
            return p == null ? NotFound() : View(p);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var p = await _context.Products.FindAsync(id);
            if (p == null) return NotFound();
            _context.Products.Remove(p);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
