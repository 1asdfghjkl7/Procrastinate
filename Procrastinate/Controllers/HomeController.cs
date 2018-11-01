using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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

        //pass in int to specify if you want only specific apis
        //pass in string of tags or null if it will work
        //pass in string of search query or null if it will work maybe empty string
        public async Task<IActionResult> Index(string tags, string search, int? whichAPIs)
        {

            using (var client = new HttpClient())
            {
                    var arrayOfArticles = new List<Articles> {  };
                if (!String.IsNullOrEmpty(tags))
                {
                    client.BaseAddress = new Uri("https://hn.algolia.com/api/v1/");
                    var response = await client.GetAsync($"https://hn.algolia.com/api/v1/search?{tags}");
                    response.EnsureSuccessStatusCode();

                    var stringResult = await response.Content.ReadAsStringAsync();
                    var jsonArticles = JsonConvert.DeserializeObject<Articles>(stringResult);

                    arrayOfArticles.Add(jsonArticles);

                    var apiResults = new ApiResults
                    {
                        Articles = arrayOfArticles
                    };

                    return View(apiResults);
                }
                if (!String.IsNullOrEmpty(search))
                {
                    client.BaseAddress = new Uri("https://hn.algolia.com/api/v1/");
                    var response = await client.GetAsync($"https://hn.algolia.com/api/v1/search_by_date?query={search}&tags=story&hitsPerPage=50");
                    response.EnsureSuccessStatusCode();

                    var stringResult = await response.Content.ReadAsStringAsync();
                    var jsonArticles = JsonConvert.DeserializeObject<Articles>(stringResult);

                    arrayOfArticles.Add(jsonArticles);

                    var apiResults = new ApiResults
                    {
                        Articles = arrayOfArticles
                    };

                    return View(apiResults);
                }
                else
                {
                try
                {
                    client.BaseAddress = new Uri("https://hn.algolia.com/api/v1/");
                    var response = await client.GetAsync($"https://hn.algolia.com/api/v1/search?tags=front_page");
                    response.EnsureSuccessStatusCode();

                    var stringResult = await response.Content.ReadAsStringAsync();
                    var jsonArticles = JsonConvert.DeserializeObject<Articles>(stringResult);

                        //client.BaseAddress = new Uri("http://localhost:8080");
                        //var response2 = await client.GetAsync($"http://localhost:8080/quote");
                        //response2.EnsureSuccessStatusCode();

                        //var stringResult2 = await response2.Content.ReadAsStringAsync();
                        //var jsonArticles2 = JsonConvert.DeserializeObject<Articles>(stringResult2);

                        arrayOfArticles.Add(jsonArticles);

                    //var thing = stringResult + stringResult2;
                    //Console.WriteLine(thing);

                    //var thing = jsonArticles.Hits;

                    //JToken token = JObject.Parse(stringResult);
                    //Array page = (Array)token.SelectToken("hits");
                    //var totalPages = token.Children()[0];
                    var apiResults = new ApiResults
                    {
                        Articles = arrayOfArticles
                    };

                    return View(apiResults);


                }
                catch (HttpRequestException httpRequestException)
                {
                    return BadRequest($"Error getting weather from OpenWeather: {httpRequestException.Message}");
                }
            }
                }

        }

        //[ActionName("IndexWithSpecificTag")]
        //public async Task<IActionResult> Index(string stri)
        //{

        //    using (var client = new HttpClient())
        //    {
        //        try
        //        {
        //            client.BaseAddress = new Uri("https://hn.algolia.com/api/v1/");
        //            var response = await client.GetAsync($"https://hn.algolia.com/api/v1/search?tags=front_page");
        //            response.EnsureSuccessStatusCode();

        //            var stringResult = await response.Content.ReadAsStringAsync();
        //            var jsonArticles = JsonConvert.DeserializeObject<Articles>(stringResult);

        //            //client.BaseAddress = new Uri("http://localhost:8080");
        //            var response2 = await client.GetAsync($"http://localhost:8080/quote");
        //            //response2.EnsureSuccessStatusCode();

        //            var stringResult2 = await response2.Content.ReadAsStringAsync();
        //            var jsonArticles2 = JsonConvert.DeserializeObject<Articles>(stringResult2);

        //            var arrayOfArticles = new Articles[] { jsonArticles, jsonArticles2 };

        //            //var thing = stringResult + stringResult2;
        //            //Console.WriteLine(thing);

        //            //var thing = jsonArticles.Hits;

        //            //JToken token = JObject.Parse(stringResult);
        //            //Array page = (Array)token.SelectToken("hits");
        //            //var totalPages = token.Children()[0];
        //            var apiResults = new ApiResults
        //            {
        //                Articles = arrayOfArticles
        //            };

        //            return View(apiResults);


        //        }
        //        catch (HttpRequestException httpRequestException)
        //        {
        //            return BadRequest($"Error getting weather from OpenWeather: {httpRequestException.Message}");
        //        }
        //    }

        //}


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
