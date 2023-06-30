using Microsoft.AspNetCore.Mvc;
using System;
    using Microsoft.EntityFrameworkCore;
using Biblioteca.Data;
using Biblioteca.Models;
using Biblioteca.Models.ViewModels;
using NuGet.Packaging.Signing;

namespace Biblioteca.Controllers
{
    public class LocacaosController : Controller
    {
        private readonly BibliotecaContext _context;

        public LocacaosController(BibliotecaContext context)
        {
            _context = context;
        }

        // Método utilitário calcular multa. Utilizado em todas as views
        public double CalculaMulta(DateTime dataPrevista)
        {
            TimeSpan diferenca = DateTime.Now - dataPrevista;

            int diasDeAtraso = (int)diferenca.TotalDays;

            if (diasDeAtraso > 0)
            {
                return diasDeAtraso * 2.50;
            }

            return 0.0;
        }

        // Método utilitário para validar campos do cadastro
        public int ValidaLocacao(Locacao locacao)
        {
            DateTime dataAtual = DateTime.Now;
            DateTime dataSemHora = locacao.DataHoraLocacao;

            if ( dataSemHora > locacao.DataPrevista )
            {
                ModelState.AddModelError("", "Data prevista tem de ser no minimo um dia a mais que a data de locação");
                return 1;
            }

            if ( dataSemHora > locacao.DataDevolucao )
            {
                ModelState.AddModelError("", "Data de devolução não pode ser menor que a data de locação");
                return 1;
            }

            if ( dataSemHora.Date < dataAtual.Date )
            {
                ModelState.AddModelError("", "Data de locação não pode ser menor que data atual, os registros devem ser cadastrados diariamente");
                return 1;
            }

            if ( locacao.ValorLocacao <= 0)
            {
                ModelState.AddModelError("", "Não são permitidos valores zerados ou negativos");
                return 1;
            }

            return 0;
        }

        // GET: Locacaos
        public async Task<IActionResult> Index()
        {
            var bibliotecaContext = _context.Locacao.Include(l => l.Cliente).Include(l => l.Livro).Include(l => l.Usuario);

            var locacoes = await bibliotecaContext.ToListAsync();

            foreach (var locacao in locacoes)
            {
                locacao.MultaAtraso = CalculaMulta(locacao.DataPrevista);
            }

            return View(locacoes);
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

            locacao.MultaAtraso = CalculaMulta(locacao.DataPrevista);

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
            int retorno;

            LocacaoFromViewModels locacaoViewModel = new LocacaoFromViewModels();
            locacaoViewModel.Locacao = locacao;
            locacaoViewModel.Clientes = _context.Cliente.ToList();
            locacaoViewModel.Livros = _context.Livro.ToList();
            locacaoViewModel.Usuarios = _context.Usuario.ToList();

            retorno = ValidaLocacao(locacao);

            if (retorno == 0)
            {
                _context.Add(locacao);
                _context.SaveChanges();

                return RedirectToAction("Index");
            } else
            {
                return View(locacaoViewModel);
            }

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
            LocacaoFromViewModels locacaoViewModel = new LocacaoFromViewModels();
            locacaoViewModel.Locacao = locacao; 
            locacaoViewModel.Clientes = _context.Cliente.ToList();
            locacaoViewModel.Livros = _context.Livro.ToList();
            locacaoViewModel.Usuarios = _context.Usuario.ToList();

            //ViewData["ClienteId"] = new SelectList(_context.Cliente, "Id", "NomeCliente", locacao.ClienteId);
            //ViewData["LivroId"] = new SelectList(_context.Livro, "Id", "NomeLivro", locacao.LivroId);
            //ViewData["UsuarioId"] = new SelectList(_context.Usuario, "Id", "Nome", locacao.UsuarioId);
            return View(locacaoViewModel);
        }

        // POST: Locacaos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(LocacaoFromViewModels viewModel)
        {
            int retorno;

            LocacaoFromViewModels locacaoViewModel = new LocacaoFromViewModels();
            locacaoViewModel.Locacao = viewModel.Locacao;
            locacaoViewModel.Clientes = _context.Cliente.ToList();
            locacaoViewModel.Livros = _context.Livro.ToList();
            locacaoViewModel.Usuarios = _context.Usuario.ToList();

            if (!_context.Livro.Any(s => s.Id == viewModel.Locacao.Id))
            {
                return NotFound();
            }

            retorno = ValidaLocacao(viewModel.Locacao);

            if (retorno == 0)
            {
                _context.Update(viewModel.Locacao);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                return View(locacaoViewModel);
            }
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

            locacao.MultaAtraso = CalculaMulta(locacao.DataPrevista);

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
