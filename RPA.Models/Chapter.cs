
using System.ComponentModel.DataAnnotations;

namespace RPA.Models
{
    public class Chapter
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "The Chapter field is required.") ]
        public string title { get; set; }
       
    }
}
