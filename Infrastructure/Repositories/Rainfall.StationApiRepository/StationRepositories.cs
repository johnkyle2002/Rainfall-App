using Microsoft.Extensions.Logging;
using Rainfall.ApiHelper.Interface;
using Rainfall.Data.Response;
using Rainfall.StationApiRepository.Interface;
namespace Rainfall.StationApiRepository
{
    public class StationRepositories : BaseApiRepository<StationModelResponse>, IStationRepositories
    {
        private readonly ILogger<BaseApiRepository<StationModelResponse>> _logger;

        public StationRepositories(ILogger<BaseApiRepository<StationModelResponse>> logger, IDomain domain, HttpClient httpClient) : base(logger, domain, httpClient)
        {
            _logger = logger;
        }

        /// <summary>
        /// A method to get the information on readings of rainfall, water levels and flows taken at a variety of measurement stations  
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<StationModelResponse?> GetStationReadingAsync(string stationId, int count)
        {
            try
            {
                return await GetAsync($"flood-monitoring/id/stations/{stationId}/readings?_limit={count}"); 
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error GetFloodAsync.");
                throw new Exception(ex.Message);
            }
        }

    }
}
