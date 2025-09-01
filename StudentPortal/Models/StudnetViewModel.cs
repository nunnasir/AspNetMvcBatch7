using StudentPortal.CustomAttributes;
using System.ComponentModel.DataAnnotations;

namespace StudentPortal.Models
{
    public class StudnetViewModel
    {
        public int Id { get; set; }
        
        [Display(Name = "Student Name")]
        [Required]
        [StringLength(10)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        [UniqueEmail]
        public string Email { get; set; }
        
        //[Required]
        //public string Password { get; set; }

        //[Compare("Password", ErrorMessage = "Password not match")]
        //public string RePassword { get; set; }

        //[Required]
        //public int PassingYear { get; set; }

        //[Range(18, 30)]
        //public int Age { get; set; }
    }
}
