using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Procrastinate.Data;
using Procrastinate.Models;
using Procrastinate.Models.SavedArticlesViewModel;

namespace Procrastinate.Views
{
    [Authorize]
    public class SavedArticlesController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly UserManager<ApplicationUser> _userManager;



        public SavedArticlesController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        // GET: SavedArticles
        public async Task<IActionResult> Index()
        {
            var curuser = await GetCurrentUserAsync();
            var applicationDbContext = _context.SavedArticles.Include(s => s.ApplicationUser).Where(s => s.ApplicationUserId == curuser.Id);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: SavedArticles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var savedArticles = await _context.SavedArticles
                .Include(s => s.ApplicationUser)
                .FirstOrDefaultAsync(m => m.SavedArticlesId == id);
            if (savedArticles == null)
            {
                return NotFound();
            }

            return View(savedArticles);
        }

        // GET: SavedArticles/Create
        public async Task<IActionResult> Create()
        {
            var user = await GetCurrentUserAsync();
            //ViewData["ApplicationUserId"] = user.Id;
            //SavedArticlesCreateViewModel model = new SavedArticlesCreateViewModel();
            //model.SavedArticles.ApplicationUserId = user.Id;
            return View();
        }

        // POST: SavedArticles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SavedArticlesId,ApplicationUserId,Title,Href")] SavedArticles savedArticles)
        {
            if (ModelState.IsValid)
            {
                _context.Add(savedArticles);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ApplicationUserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", savedArticles.ApplicationUserId);
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
            ViewData["ApplicationUserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", savedArticles.ApplicationUserId);
            return View(savedArticles);
        }

        // POST: SavedArticles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SavedArticlesId,ApplicationUserId,Title,Href")] SavedArticles savedArticles)
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
            ViewData["ApplicationUserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", savedArticles.ApplicationUserId);
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
                .Include(s => s.ApplicationUser)
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
