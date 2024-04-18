using RPA.Application.Implemettions.Base;
using RPA.Application.Interfaces;
using RPA.Models;


namespace RPA.Application.Implemettions
{
    public class ChapterServiceRepogitory : GRepository<Chapter> , IChapterServiceRepogitory
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ChapterServiceRepogitory(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
    }
}
