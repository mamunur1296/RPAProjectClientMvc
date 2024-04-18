using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPA.Models
{
    public class Topic
    {
        public Guid Id { get; set; }
        public string title { get; set; }
        public Guid Chapterid { get; set; }
        public List<Questions>? QuestionsList { get; set; }
    }
}
