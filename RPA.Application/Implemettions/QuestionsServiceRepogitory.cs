using RPA.Application.Implemettions.Base;
using RPA.Application.Interfaces;
using RPA.Models;

namespace RPA.Application.Implemettions
{
    public class QuestionsServiceRepogitory : GRepository<Questions>, IQuestionsServiceRepogitory
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public QuestionsServiceRepogitory(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
    }
}
