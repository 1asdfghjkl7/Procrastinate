using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Procrastinate.Data;
using Procrastinate.Models;

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


        public async Task<IActionResult> Index()
        {

            using (var client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = new Uri("https://hn.algolia.com/api/v1/");
                    var response = await client.GetAsync($"https://hn.algolia.com/api/v1/search?tags=front_page");
                    response.EnsureSuccessStatusCode();

                    var stringResult = await response.Content.ReadAsStringAsync();
                    var rawWeather = JsonConvert.DeserializeObject<Articles>(stringResult);
                    var thing = rawWeather.Hits;

                    JToken token = JObject.Parse(stringResult);
                    //Array page = (Array)token.SelectToken("hits");
                    var totalPages = token.Children()[0];


                    return View(rawWeather);


                }
                catch (HttpRequestException httpRequestException)
                {
                    return BadRequest($"Error getting weather from OpenWeather: {httpRequestException.Message}");
                }
            }

        }

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
            
            //ViewData["ApplicationUserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", savedArticles.ApplicationUserId);
            //return View(savedArticles);
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
