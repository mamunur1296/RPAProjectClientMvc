

namespace RPA.Models.ViewModel
{
    public class TopicCreateViewModel
    {
        public Topic  Topic { get; set; } = new Topic();
        public List<Chapter> Chapter { get; set; } =  new List<Chapter>();
    }
}
