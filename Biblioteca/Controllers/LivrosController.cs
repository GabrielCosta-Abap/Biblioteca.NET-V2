
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Biblioteca.Data;
using Biblioteca.Models;
using Biblioteca.Models.ViewModels;

namespace Biblioteca.Controllers
{
    public class LivrosController : Controller
    {
        private readonly BibliotecaContext _context;

        public LivrosController(BibliotecaContext context)
        {
            _context = context;
        }

        // Método utilitário para validar campos do cadastro
        public int ValidaLivro(Livro livro)
        {
            int anoAtual = DateTime.Now.Year;

            if (livro.Ano < 1000 || livro.Ano > anoAtual)
            {
                ModelState.AddModelError("", "Ano não pode ser menor que 1000 e nem maior que o ano atual");
                return 1;
            }

            if (livro.ValorLocacao <= 0 || livro.NumVolume <= 0 || livro.QtdVolumes <= 0)
            {
                ModelState.AddModelError("", "Não são permitidos valores zerados ou negativos");
                return 1;
            }

            return 0;
        }

        // GET: Livros
        public async Task<IActionResult> Index()
        {
              return _context.Livro != null ? 
                          View(await _context.Livro.ToListAsync()) :
                          Problem("Entity set 'BibliotecaContext.Livro'  is null.");
        }

        // GET: Livros/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null || _context.Livro == null)
            {
                return NotFound();
            }

            LivroFromViewModels LivroViewModel = new LivroFromViewModels();
            LivroViewModel.Livro =  _context.Livro.FirstOrDefault(m => m.Id == id);

            Console.WriteLine("ID DO LIVRO: ", LivroViewModel.Livro.Id);

            LivroViewModel.Locacaos = _context.Locacao
                                            .Include(l => l.Cliente)
                                            .Where(l => l.LivroId == id)
                                            .ToList();

            if (LivroViewModel == null)
            {
                return NotFound();
            }

            return View(LivroViewModel);
        }

        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null || _context.Livro == null)
        //    {
        //        return NotFound();
        //    }

        //    LivroFromViewModels LivroViewModel = new LivroFromViewModels();
        //    //LivroViewModel.Livro = await _context.Livro.FirstOrDefaultAsync(m => m.Id == id);
        //    LivroViewModel.Livro = await _context.Livro.FirstOrDefault(m => m.Id == id);

        //    Console.WriteLine("ID DO LIVRO: ", LivroViewModel.Livro.Id);

        //    LivroViewModel.Locacaos = _context.Locacao
        //        .Where(l => l.LivroId == id)
        //        .Include(l => l.Cliente)
        //        .ToList(); 


        //    //var livro = await _context.Livro.FirstOrDefaultAsync(m => m.Id == id);
        //    if (LivroViewModel == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(LivroViewModel);
        //}

        // GET: Livros/Create
        public IActionResult Create()
        {
            LivroFromViewModels livroViewModel = new LivroFromViewModels();
            livroViewModel.Autors = _context.Autor.ToList();
            return View(livroViewModel);
        }

        // POST: Livros/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Livro livro)
        {
            int retorno;

            LivroFromViewModels livroViewModel = new LivroFromViewModels();
            livroViewModel.Autors = _context.Autor.ToList();

            retorno = ValidaLivro(livro);

            if (retorno == 0)
            {
                _context.Add(livro);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                return View(livroViewModel);
            }
        }

        // GET: Livros/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Livro == null)
            {
                return NotFound();
            }

            var livro = await _context.Livro.FindAsync(id);
            if (livro == null)
            {
                return NotFound();
            }

            LivroFromViewModels LivroViewModel = new LivroFromViewModels();
            LivroViewModel.Livro = livro;
            LivroViewModel.Autors = _context.Autor.ToList();

            return View(LivroViewModel);
        }

        // POST: Livros/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(LivroFromViewModels viewModel)
        {
            int retorno;

            LivroFromViewModels livroViewModel = new LivroFromViewModels();
            livroViewModel.Autors = _context.Autor.ToList();

            if (!_context.Livro.Any(s => s.Id == viewModel.Livro.Id))
            {
                return NotFound();
            }

            retorno = ValidaLivro(viewModel.Livro);

            if (retorno == 0)
            {
                _context.Update(viewModel.Livro);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                return View(livroViewModel);
            }
        }

        // GET: Livros/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Livro == null)
            {
                return NotFound();
            }

            var livro = await _context.Livro
                .FirstOrDefaultAsync(m => m.Id == id);
            if (livro == null)
            {
                return NotFound();
            }

            return View(livro);
        }

        // POST: Livros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Livro == null)
            {
                return Problem("Entity set 'BibliotecaContext.Livro'  is null.");
            }
            var livro = await _context.Livro.FindAsync(id);
            if (livro != null)
            {
                _context.Livro.Remove(livro);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LivroExists(int id)
        {
          return (_context.Livro?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
