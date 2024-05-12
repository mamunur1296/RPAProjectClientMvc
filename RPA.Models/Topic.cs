using System.ComponentModel.DataAnnotations;

namespace RPA.Models
{
    public class Topic
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "The Topic field is required.")]
        public string title { get; set; }
        [Required(ErrorMessage = "The Chapter field is required.")]
        public Guid Chapterid { get; set; }
        public List<Questions>? QuestionsList { get; set; }
    }
}
