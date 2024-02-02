using System.ComponentModel.DataAnnotations;

namespace Rainfall.DataTransferObject.Request
{
    public record StationRequestDto
    {
        [Required]
        public required string Id { get; set; }

        [Range(1, 100)]
        public int Count { get; set; } = 10; 
    }
}
