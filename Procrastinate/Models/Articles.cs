using System.Collections.Generic;

namespace Procrastinate.Models
{
    public class ApiResults
    {
        public List<Articles> Articles { get; set; }
    }
    public class Articles
    {
        public IEnumerable<Hits> Hits { get; set; }
    }
    public class Hits
    {
        public string Title { get; set; }

        public string Url { get; set; }
    }
}