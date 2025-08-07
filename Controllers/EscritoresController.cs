using LivroCadastro.Data;
using LivroCadastro.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LivroCadastro.Controllers
{
    public class EscritoresController : Controller
    {
        private readonly AppDbContext _context;

        public EscritoresController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index() =>
            View(await _context.Escritores.ToListAsync());

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(Escritor escritor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(escritor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(escritor);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var escritor = await _context.Escritores.FindAsync(id);
            return escritor == null ? NotFound() : View(escritor);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Escritor escritor)
        {
            if (ModelState.IsValid)
            {
                _context.Update(escritor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(escritor);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var escritor = await _context.Escritores.FindAsync(id);
            return View(escritor);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var escritor = await _context.Escritores.FindAsync(id);
            _context.Escritores.Remove(escritor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
