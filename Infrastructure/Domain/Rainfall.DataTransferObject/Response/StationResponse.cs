using Newtonsoft.Json;

namespace Rainfall.DataTransferObject.Response
{
    public record StationResponse
    {
        [JsonProperty("dateMeasured")]
        public string? DateMeasured { get; set; }

        [JsonProperty("amountMeasured")]
        public decimal AmountMeasured { get; set; }
    }
}
