using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Procrastinate.Models
{
    public class SavedArticles
    {
        [Key]
        public int SavedArticlesId { get; set; }
        
        [Required]
        public int UserId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Href { get; set; }
    }
}
