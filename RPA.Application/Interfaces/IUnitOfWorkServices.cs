namespace RPA.Application.Interfaces
{
    public interface IUnitOfWorkServices 
    {
        IChapterServiceRepogitory chapterServiceRepogitory { get; }
        IQuestionsServiceRepogitory questionsServiceRepogitory { get;}
        ITopicServiceRepogitory topicServiceRepogitory { get;}
    }
}
