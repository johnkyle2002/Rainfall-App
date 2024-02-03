using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Rainfall.ApiHelper.Interface;

namespace Rainfall.StationApiRepository
{
    public class BaseApiRepository<TModel> where TModel : class
    {
        private readonly ILogger<BaseApiRepository<TModel>> _logger;
        private readonly IDomain _domain;
        private readonly HttpClient _httpClient;

        public BaseApiRepository(ILogger<BaseApiRepository<TModel>> logger,
             IDomain domain,
            HttpClient httpClient)
        {

            _logger = logger;
            _domain = domain;
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(domain.BaseUrl());
        }


        public async Task<TModel?> GetAsync(string endpoint, string? parameter = null, Dictionary<string, string>? header = null)
        {
            var url = $"/{endpoint}{parameter}";

            AddHeader(_httpClient, _domain.Header());
            AddHeader(_httpClient, header);

            var result = await _httpClient.GetAsync(url);

            if (result.IsSuccessStatusCode)
            {
                var contentBody = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<TModel>(contentBody);
            }
            else
            {
                _logger.LogError("Error: {LogStatus} : {LogError}", result.StatusCode, result.ReasonPhrase);
                return null;
            }
        }

        public string Getparameter(List<KeyValuePair<string, string>>? request)
        {
            if (request != null && request.Any())
                return "?" + string.Join("&", request.Select(s => $"{s.Key}={s.Value}"));

            return string.Empty;
        }

        public void AddHeader(HttpClient httpClient, Dictionary<string, string>? header)
        {
            if (header != null && header.Any())
                foreach (var item in header)
                {
                    httpClient.DefaultRequestHeaders.Add(item.Key, item.Value);
                }
        }
    }
}
