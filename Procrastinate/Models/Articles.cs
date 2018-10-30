using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Procrastinate.Models
{
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