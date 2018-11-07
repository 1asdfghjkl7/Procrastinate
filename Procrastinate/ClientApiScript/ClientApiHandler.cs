using Newtonsoft.Json;
using Procrastinate.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Procrastinate.ClientApiScript
{
    public class ClientApiHandler
    {
        public async Task<ApiResults> ClientApiSearch(string search)
        {
            List<string> apiStringSearch = new List<string>();

            apiStringSearch.Add("https://hn.algolia.com/api/v1/search_by_date?tags=story&hitsPerPage=50&query=");
            apiStringSearch.Add("http://localhost:8080/quote?q=");

            var arrayOfArticles = new List<Articles> { };
            var apiResults = new ApiResults
            {
                Articles = arrayOfArticles
            };

            if (!String.IsNullOrEmpty(search))
            {
                foreach (var item in apiStringSearch)
                {
                    var client = new HttpClient();
                    try
                    {
                        var response = await client.GetAsync(item + search);
                        var stringResult = await response.Content.ReadAsStringAsync();
                        var jsonArticles = JsonConvert.DeserializeObject<Articles>(stringResult);

                        arrayOfArticles.Add(jsonArticles);
                    }
                    catch (HttpRequestException httpRequestException)
                    {
                        continue;
                    }

                }
            }

            return apiResults;
        }

        public async Task<ApiResults> ClientApiTag(string tags)
        {
            List<string> apiStringTag = new List<string>();

            apiStringTag.Add($"https://hn.algolia.com/api/v1/search_by_date?{tags}");
            //apiStringTag.Add("http://localhost:8080/quote?q=");

            var arrayOfArticles = new List<Articles> { };
            var apiResults = new ApiResults
            {
                Articles = arrayOfArticles
            };

            if (!String.IsNullOrEmpty(tags))
            {
                foreach (var item in apiStringTag)
                {
                    var client = new HttpClient();
                    try
                    {
                        var response = await client.GetAsync(item);
                        var stringResult = await response.Content.ReadAsStringAsync();
                        var jsonArticles = JsonConvert.DeserializeObject<Articles>(stringResult);

                        arrayOfArticles.Add(jsonArticles);
                    }
                    catch (HttpRequestException httpRequestException)
                    {
                        continue;
                    }

                }
            }

            return apiResults;
        }

        public async Task<ApiResults> ClientApiDefault()
        {
            List<string> frontPageApiStrings = new List<string>();

            frontPageApiStrings.Add("https://hn.algolia.com/api/v1/search_by_date?tags=front_page");
            frontPageApiStrings.Add("http://localhost:8080/quote");

            var arrayOfArticles = new List<Articles> { };
            var apiResults = new ApiResults
            {
                Articles = arrayOfArticles
            };

            foreach (var item in frontPageApiStrings)
            {
                var client = new HttpClient();
                try
                {
                    var response = await client.GetAsync(item);
                    var stringResult = await response.Content.ReadAsStringAsync();
                    var jsonArticles = JsonConvert.DeserializeObject<Articles>(stringResult);

                    arrayOfArticles.Add(jsonArticles);
                }
                catch (HttpRequestException httpRequestException)
                {
                    continue;
                }

            }
            return apiResults;
        }

    }
}
