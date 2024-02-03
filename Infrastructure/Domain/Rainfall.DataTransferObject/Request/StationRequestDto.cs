using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Rainfall.DataTransferObject.Request
{
    /// <summary>
    /// Rainfall Station request query parameter
    /// </summary> 
    public record StationRequestDto
    {
        /// <summary>
        /// station ID
        /// </summary>
        [RegularExpression("[0-9a-zA-Z]*")]
        [SwaggerParameter(Description = "The id of the reading station.", Required = true)]
        public required string stationId { get; set; }

        /// <summary>
        /// Limit of the record
        /// </summary>
        [Required]
        [Range(1, 100)]
        [FromQuery]
        [DefaultValue(10)]
        public int Count { get; set; }
    }
}
