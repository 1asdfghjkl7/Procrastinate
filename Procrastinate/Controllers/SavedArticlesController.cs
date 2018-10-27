using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Procrastinate.Data;
using Procrastinate.Models;

namespace Procrastinate.Controllers
{
    [Authorize]
    public class SavedArticlesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SavedArticlesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SavedArticles
        public async Task<IActionResult> Index()
        {
            return View(await _context.SavedArticles.ToListAsync());
        }

        // GET: SavedArticles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var savedArticles = await _context.SavedArticles
                .FirstOrDefaultAsync(m => m.SavedArticlesId == id);
            if (savedArticles == null)
            {
                return NotFound();
            }

            return View(savedArticles);
        }

        // GET: SavedArticles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SavedArticles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SavedArticlesId,UserId,Title,Href")] SavedArticles savedArticles)
        {
            if (ModelState.IsValid)
            {
                _context.Add(savedArticles);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(savedArticles);
        }

        // GET: SavedArticles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var savedArticles = await _context.SavedArticles.FindAsync(id);
            if (savedArticles == null)
            {
                return NotFound();
            }
            return View(savedArticles);
        }

        // POST: SavedArticles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SavedArticlesId,UserId,Title,Href")] SavedArticles savedArticles)
        {
            if (id != savedArticles.SavedArticlesId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(savedArticles);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SavedArticlesExists(savedArticles.SavedArticlesId))
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
            return View(savedArticles);
        }

        // GET: SavedArticles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var savedArticles = await _context.SavedArticles
                .FirstOrDefaultAsync(m => m.SavedArticlesId == id);
            if (savedArticles == null)
            {
                return NotFound();
            }

            return View(savedArticles);
        }

        // POST: SavedArticles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var savedArticles = await _context.SavedArticles.FindAsync(id);
            _context.SavedArticles.Remove(savedArticles);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SavedArticlesExists(int id)
        {
            return _context.SavedArticles.Any(e => e.SavedArticlesId == id);
        }
    }
}
