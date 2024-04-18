using Newtonsoft.Json;
using RPA.Application.Implemettions.Base;
using RPA.Application.Interfaces;
using RPA.Models;
using RPA.Models.ViewModel;
using System.Text;

namespace RPA.Application.Implemettions
{
    public class TopicServiceRepogitory : GRepository<Topic>, ITopicServiceRepogitory
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public TopicServiceRepogitory(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<bool> AddTopicAndChapterAsync(TopicCreateViewModel model, string EndPoint)
        {

            var httpClient = _httpClientFactory.CreateClient("apiClient");
            var json = JsonConvert.SerializeObject(model);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(EndPoint, content);

            if (response.IsSuccessStatusCode)
            {
                //var jsonString = await response.Content.ReadAsStringAsync();
                return true;
            }
            else
            {
                throw new HttpRequestException($"Failed to add resource. Status code: {response.StatusCode}");
            }
        }
    }
}
