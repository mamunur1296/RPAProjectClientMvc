using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPA.Models
{
    public class Questions
    {
        public Guid Id { get; set; }
        public string title { get; set; }
        public string answers { get; set; }
        public Guid TopicId { get; set; }
    }
}
