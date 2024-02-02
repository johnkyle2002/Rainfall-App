namespace Rainfall.StationApiRepository
{
    public class StationRepositories
    {
        private readonly HttpClient _httpClient;

        public StationRepositories(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
    }
}
