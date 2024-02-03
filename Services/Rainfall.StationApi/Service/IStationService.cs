using Rainfall.DataTransferObject.Response;

namespace Rainfall.StationApi.Service
{
    public interface IStationService
    {
        Task<IEnumerable<StationResponse>> GetStationReadingAsync(string stationId, int count);
    }
}