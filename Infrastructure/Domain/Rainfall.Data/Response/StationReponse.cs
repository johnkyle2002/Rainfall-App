using Newtonsoft.Json;

namespace Rainfall.Data.Response
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class StationItem
    {
        [JsonProperty("@id")]
        public string id { get; set; }

        [JsonProperty("dateTime")]
        public DateTime dateTime { get; set; }

        [JsonProperty("measure")]
        public string measure { get; set; }

        [JsonProperty("value")]
        public double value { get; set; }
    }

    public class Meta
    {
        [JsonProperty("publisher")]
        public string publisher { get; set; }

        [JsonProperty("licence")]
        public string licence { get; set; }

        [JsonProperty("documentation")]
        public string documentation { get; set; }

        [JsonProperty("version")]
        public string version { get; set; }

        [JsonProperty("comment")]
        public string comment { get; set; }

        [JsonProperty("hasFormat")]
        public List<string> hasFormat { get; set; }

        [JsonProperty("limit")]
        public int limit { get; set; }
    }

    public class Station
    {
        [JsonProperty("@context")]
        public string context { get; set; }

        [JsonProperty("meta")]
        public Meta meta { get; set; }

        [JsonProperty("items")]
        public List<StationItem> items { get; set; }
    }  
}
