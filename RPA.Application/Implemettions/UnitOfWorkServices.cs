using RPA.Application.Implemettions;
using RPA.Application.Interfaces;


namespace RPA.Services.Implemettions
{
    public class UnitOfWorkServices : IUnitOfWorkServices
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public IChapterServiceRepogitory chapterServiceRepogitory {  get; private set; }

        public IQuestionsServiceRepogitory questionsServiceRepogitory { get; private set; }

        public ITopicServiceRepogitory topicServiceRepogitory { get; private set; }

        public UnitOfWorkServices(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            chapterServiceRepogitory = new ChapterServiceRepogitory(httpClientFactory);
            questionsServiceRepogitory = new QuestionsServiceRepogitory(httpClientFactory);
            topicServiceRepogitory = new TopicServiceRepogitory(httpClientFactory);
        }

    }
}
