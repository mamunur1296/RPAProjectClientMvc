

namespace RPA.Models.ViewModel
{
    public class QuestionsCreateViewModel
    {
        public Questions Questions { get; set; } = new Questions();
        public List<Topic> TopicList { get; set; } = new List<Topic>();
    }
}
