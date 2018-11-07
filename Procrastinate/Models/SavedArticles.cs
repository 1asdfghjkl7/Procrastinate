using System.ComponentModel.DataAnnotations;

namespace Procrastinate.Models
{
    public class SavedArticles
    {
        [Key]
        public int SavedArticlesId { get; set; }
        
        [Required]
        public string ApplicationUserId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Href { get; set; }
    }
}
