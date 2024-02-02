using Newtonsoft.Json;

namespace Rainfall.DataTransferObject.Response
{
    public record ErrorResponse
    {
        [JsonProperty("message")]
        public string? Message { get; set; }

        public int MyProperty { get; set; }
    }

    public record ErrorDetail
    {
        public string? PropertyName { get; set; }
        public string? Message { get; set; }
        public bool AdditionalProperties { get; set; }
    }
}
