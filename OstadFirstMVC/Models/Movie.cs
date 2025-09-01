using System.ComponentModel.DataAnnotations;

namespace OstadFirstMVC.Models
{
    public class Movie
    {
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; } 


        public string genre { get; set; }
    }
}
