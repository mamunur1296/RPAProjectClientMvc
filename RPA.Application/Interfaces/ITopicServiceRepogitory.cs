using RPA.Application.Interfaces.Base;
using RPA.Models;
using RPA.Models.ViewModel;

namespace RPA.Application.Interfaces
{
    public interface ITopicServiceRepogitory : IGReopgitory<Topic>
    {
        // Extained 
        Task<bool> AddTopicAndChapterAsync(TopicCreateViewModel model, string EndPoint);
    }
}
