using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Procrastinate.Data;
using Procrastinate.Models;
using Procrastinate.ClientApiScript;

namespace Procrastinate.Controllers
{
    public class HomeController : Controller
    {

        private readonly ApplicationDbContext _context;

        private readonly UserManager<ApplicationUser> _userManager;



        public HomeController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        //pass in string of tags or null
        //pass in string of search query or null
        [Authorize]
        public async Task<IActionResult> Index(string tags, string search, int? whichAPIs)
        {
            if (!String.IsNullOrEmpty(search))
            {
                return View(await new ClientApiHandler().ClientApiSearch(search));
            }
            else if (!String.IsNullOrEmpty(tags))
            {
                return View(await new ClientApiHandler().ClientApiTag(tags));
            }
            else
            {
                return View(await new ClientApiHandler().ClientApiDefault());
            }
        }




        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(string Title, string Href)
        {
            var curuser = await GetCurrentUserAsync();
            SavedArticles savedArticles = new SavedArticles();
            savedArticles.Title = Title;
            savedArticles.Href = Href;
            savedArticles.ApplicationUserId = curuser.Id;
            _context.Add(savedArticles);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
