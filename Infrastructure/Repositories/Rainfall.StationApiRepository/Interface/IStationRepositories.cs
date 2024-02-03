using Rainfall.Data.Response;
using Rainfall.DataTransferObject.Response;

namespace Rainfall.StationApiRepository.Interface
{
    public interface IStationRepositories
    {
        Task<StationModelResponse?> GetStationReadingAsync(string stationId, int count);
    }
}