using Newtonsoft.Json;

namespace Rainfall.Data.Response
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class StationItem
    {
        [JsonProperty("@id")]
        public string? Id { get; set; }

        [JsonProperty("dateTime")]
        public DateTime DateTime { get; set; }

        [JsonProperty("measure")]
        public string? Measure { get; set; }

        [JsonProperty("value")]
        public decimal? Value { get; set; }
    }

    public class StationMeta
    {
        [JsonProperty("publisher")]
        public string? Publisher { get; set; }

        [JsonProperty("licence")]
        public string? Licence { get; set; }

        [JsonProperty("documentation")]
        public string? documentation { get; set; }

        [JsonProperty("version")]
        public string? Version { get; set; }

        [JsonProperty("comment")]
        public string? Comment { get; set; }

        [JsonProperty("hasFormat")]
        public List<string>? HasFormat { get; set; }

        [JsonProperty("limit")]
        public int? Limit { get; set; }
    }

    public class StationModelResponse
    {
        [JsonProperty("@context")]
        public string? Context { get; set; }

        [JsonProperty("meta")]
        public StationMeta? Meta { get; set; }

        [JsonProperty("items")]
        public List<StationItem>? Items { get; set; }
    }  
}
