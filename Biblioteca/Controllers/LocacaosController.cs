using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Biblioteca.Data;
using Biblioteca.Models;
using Biblioteca.Models.ViewModels;

namespace Biblioteca.Controllers
{
    public class LocacaosController : Controller
    {
        private readonly BibliotecaContext _context;

        public LocacaosController(BibliotecaContext context)
        {
            _context = context;
        }

        // GET: Locacaos
        public async Task<IActionResult> Index()
        {
            var bibliotecaContext = _context.Locacao.Include(l => l.Cliente).Include(l => l.Livro).Include(l => l.Usuario);
            return View(await bibliotecaContext.ToListAsync());
        }

        // GET: Locacaos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Locacao == null)
            {
                return NotFound();
            }

            var locacao = await _context.Locacao
                .Include(l => l.Cliente)
                .Include(l => l.Livro)
                .Include(l => l.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (locacao == null)
            {
                return NotFound();
            }

            return View(locacao);
        }

        // GET: Locacaos/Create
        public IActionResult Create()
        {
            LocacaoFromViewModels livroViewModel = new LocacaoFromViewModels();

            livroViewModel.Livros = _context.Livro.ToList();
            livroViewModel.Clientes = _context.Cliente.ToList();
            livroViewModel.Usuarios = _context.Usuario.ToList();

            return View(livroViewModel);
        }

        // POST: Locacaos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Locacao locacao)
        {
            _context.Add(locacao);
            _context.SaveChanges();

            return RedirectToAction("Index");
            //if (ModelState.IsValid)
            //{
            //    _context.Add(locacao);
            //    await _context.SaveChangesAsync();
            //    return RedirectToAction(nameof(Index));
            //}
            //ViewData["ClienteId"] = new SelectList(_context.Cliente, "Id", "Id", locacao.ClienteId);
            //ViewData["LivroId"] = new SelectList(_context.Livro, "Id", "Id", locacao.LivroId);
            //ViewData["UsuarioId"] = new SelectList(_context.Usuario, "Id", "Id", locacao.UsuarioId);
            //return View(locacao);
        }

        // GET: Locacaos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Locacao == null)
            {
                return NotFound();
            }

            var locacao = await _context.Locacao.FindAsync(id);
            if (locacao == null)
            {
                return NotFound();
            }
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "Id", "Id", locacao.ClienteId);
            ViewData["LivroId"] = new SelectList(_context.Livro, "Id", "Id", locacao.LivroId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "Id", "Id", locacao.UsuarioId);
            return View(locacao);
        }

        // POST: Locacaos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,LivroId,ClienteId,UsuarioId,DataHoraLocacao,DataPrevista,DataDevolucao,ValorLocacao,MultaAtraso")] Locacao locacao)
        {
            if (id != locacao.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(locacao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LocacaoExists(locacao.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "Id", "Id", locacao.ClienteId);
            ViewData["LivroId"] = new SelectList(_context.Livro, "Id", "Id", locacao.LivroId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "Id", "Id", locacao.UsuarioId);
            return View(locacao);
        }

        // GET: Locacaos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Locacao == null)
            {
                return NotFound();
            }

            var locacao = await _context.Locacao
                .Include(l => l.Cliente)
                .Include(l => l.Livro)
                .Include(l => l.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (locacao == null)
            {
                return NotFound();
            }

            return View(locacao);
        }

        // POST: Locacaos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Locacao == null)
            {
                return Problem("Entity set 'BibliotecaContext.Locacao'  is null.");
            }
            var locacao = await _context.Locacao.FindAsync(id);
            if (locacao != null)
            {
                _context.Locacao.Remove(locacao);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LocacaoExists(int id)
        {
          return (_context.Locacao?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
