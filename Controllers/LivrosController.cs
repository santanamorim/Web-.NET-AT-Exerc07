using Microsoft.AspNetCore.Mvc;
using Web_.NET_AT_Exerc07.Data;
using Web_.NET_AT_Exerc07.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Web_.NET_AT_Exerc07.Controllers
{
    public class LivrosController : Controller
    {
        private readonly LivroContext _context;

        public LivrosController(LivroContext context)
        {
            _context = context;
        }

        // Exibir lista de livros
        public async Task<IActionResult> Index()
        {
            var livros = await _context.Livros.ToListAsync();
            return View(livros); // Garante que a lista será atualizada
        }

        // Adicionar um novo livro
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Titulo,Autor")] Livro livro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(livro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(livro);
        }

        // Exibir a confirmação de exclusão de um livro
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var livro = await _context.Livros.FirstOrDefaultAsync(m => m.Id == id);
            if (livro == null)
            {
                return NotFound();
            }

            return View(livro);
        }

        // Confirmar a exclusão de um livro
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
            return RedirectToAction(nameof(Index)); // Redireciona para a lista de livros
        }
    }
}
