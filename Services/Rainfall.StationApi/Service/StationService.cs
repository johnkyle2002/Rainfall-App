using Rainfall.DataTransferObject.Response;
using Rainfall.StationApiRepository.Interface;
using System.Globalization;

namespace Rainfall.StationApi.Service
{
    /// <summary>
    /// 
    /// </summary>
    public class StationService : IStationService
    {
        private readonly IStationRepositories _stationRepositories;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stationRepositories"></param>
        public StationService(IStationRepositories stationRepositories)
        {
            _stationRepositories = stationRepositories;
        }

        /// <summary>
        /// assosiated with https://environment.data.gov.uk/flood-monitoring/id/stations/{stationId}/readings
        /// </summary>
        /// <param name="stationId"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public async Task<IEnumerable<StationResponse>> GetStationReadingAsync(string stationId, int count)
        {
            try
            {
                var data = await _stationRepositories.GetStationReadingAsync(stationId, count);

                if (data is not null && data.Items is not null && data.Items.Any())
                {
                    CultureInfo ukCulture = new CultureInfo("en-GB");
                    return data.Items.Select(s => new StationResponse
                    {
                        AmountMeasured = s.Value,
                        DateMeasured = s.DateTime.ToString("f", ukCulture)
                    }).ToList();
                }
                return Enumerable.Empty<StationResponse>();
            }
            catch (Exception)
            {

            }
            return null;
        }
    }
}
