using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Negozio.Core.Models;
using Negozio.DataAccess.Sql;

namespace Negozio.web.UI.Controllers
{
    public class CategoriaProdottisController : Controller
    {
        private readonly DataContext _context;

        public CategoriaProdottisController(DataContext context)
        {
            _context = context;
        }

        // GET: CategoriaProdottis
        public async Task<IActionResult> Index()
        {
            return View(await _context.ProductCategories.ToListAsync());
        }

        // GET: CategoriaProdottis/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoriaProdotti = await _context.ProductCategories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (categoriaProdotti == null)
            {
                return NotFound();
            }

            return View(categoriaProdotti);
        }

        // GET: CategoriaProdottis/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CategoriaProdottis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Category,Id,CreatedAt")] CategoriaProdotti categoriaProdotti)
        {
            if (ModelState.IsValid)
            {
                _context.Add(categoriaProdotti);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(categoriaProdotti);
        }

        // GET: CategoriaProdottis/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoriaProdotti = await _context.ProductCategories.FindAsync(id);
            if (categoriaProdotti == null)
            {
                return NotFound();
            }
            return View(categoriaProdotti);
        }

        // POST: CategoriaProdottis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Category,Id,CreatedAt")] CategoriaProdotti categoriaProdotti)
        {
            if (id != categoriaProdotti.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(categoriaProdotti);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoriaProdottiExists(categoriaProdotti.Id))
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
            return View(categoriaProdotti);
        }

        // GET: CategoriaProdottis/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoriaProdotti = await _context.ProductCategories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (categoriaProdotti == null)
            {
                return NotFound();
            }

            return View(categoriaProdotti);
        }

        // POST: CategoriaProdottis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var categoriaProdotti = await _context.ProductCategories.FindAsync(id);
            _context.ProductCategories.Remove(categoriaProdotti);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoriaProdottiExists(string id)
        {
            return _context.ProductCategories.Any(e => e.Id == id);
        }
    }
}
