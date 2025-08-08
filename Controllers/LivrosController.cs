using LivroCadastro.Data;
using LivroCadastro.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace LivroCadastro.Controllers
{
    public class LivrosController : Controller
    {
        private readonly AppDbContext _context;

        public LivrosController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index() =>
            View(await _context.Livros.Include(l => l.Escritor).ToListAsync());

        public IActionResult Create()
        {
            ViewBag.EscritorId = new SelectList(_context.Escritores, "EscritorId", "Nome");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Livro livro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(livro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.EscritorId = new SelectList(_context.Escritores, "EscritorId", "Nome", livro.EscritorId);
            return View(livro);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var livro = await _context.Livros.FindAsync(id);
            if (livro == null) return NotFound();
            ViewBag.EscritorId = new SelectList(_context.Escritores, "EscritorId", "Nome", livro.EscritorId);
            return View(livro);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Livro livro)
        {
            if (ModelState.IsValid)
            {
                _context.Update(livro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.EscritorId = new SelectList(_context.Escritores, "EscritorId", "Nome", livro.EscritorId);
            return View(livro);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var livro = await _context.Livros.Include(l => l.Escritor).FirstOrDefaultAsync(m => m.LivroId == id);
            return livro == null ? NotFound() : View(livro);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var livro = await _context.Livros.FindAsync(id);
            if (livro != null)
            {
                _context.Livros.Remove(livro);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
