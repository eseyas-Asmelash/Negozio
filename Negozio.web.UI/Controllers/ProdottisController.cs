using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Negozio.Core.Models;
using Negozio.Core.ViewModels;
using Negozio.DataAccess.Sql;

namespace Negozio.web.UI.Controllers
{
    public class ProdottisController : Controller
    {
        private readonly DataContext _context;

        public ProdottisController(DataContext context)
        {
            _context = context;
        }

        // GET: Prodottis
        public async Task<IActionResult> Index()
        {
            return View(await _context.Products.ToListAsync());
        }

        // GET: Prodottis/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prodotti = await _context.Products
                .FirstOrDefaultAsync(m => m.Id == id);
            if (prodotti == null)
            {
                return NotFound();
            }

            return View(prodotti);
        }

        // GET: Prodottis/Create
        public IActionResult Create()
        {
            ProdottiAmministrazione viewModel = new ProdottiAmministrazione();

            viewModel.Prodotti= new Prodotti();
            viewModel.CategoriaProdotti = CategoriaProdotti.Collection();
            return View(viewModel);

        }

        // POST: Prodottis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Description,Price,Category,Image,Id,CreatedAt")] Prodotti prodotti)
        {
            if (ModelState.IsValid)
            {
                _context.Add(prodotti);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(prodotti);
        }

        // GET: Prodottis/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prodotti = await _context.Products.FindAsync(id);
            if (prodotti == null)
            {
                return NotFound();
            }
            return View(prodotti);
        }

        // POST: Prodottis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Name,Description,Price,Category,Image,Id,CreatedAt")] Prodotti prodotti)
        {
            if (id != prodotti.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(prodotti);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProdottiExists(prodotti.Id))
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
            return View(prodotti);
        }

        // GET: Prodottis/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prodotti = await _context.Products
                .FirstOrDefaultAsync(m => m.Id == id);
            if (prodotti == null)
            {
                return NotFound();
            }

            return View(prodotti);
        }

        // POST: Prodottis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var prodotti = await _context.Products.FindAsync(id);
            _context.Products.Remove(prodotti);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProdottiExists(string id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
