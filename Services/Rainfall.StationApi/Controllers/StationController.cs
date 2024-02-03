using Microsoft.AspNetCore.Mvc;
using Rainfall.DataTransferObject.Request;
using Rainfall.DataTransferObject.Response;
using Rainfall.StationApi.Service;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel;
using System.Net;

namespace Rainfall.StationApi.Controllers
{
    /// <summary>
    /// Station Controller
    /// </summary>
    [Route("rainfall/")]
    [ApiController]
    [ControllerName("rainfall")]
    [Description("Operations relating to rainfall")]
    public class StationController : ControllerBase
    {
        private readonly IStationService _stationService;

        /// <summary>
        /// Station Constructor
        /// </summary>
        public StationController(IStationService stationService)
        {
            _stationService = stationService;
        }

        /// <summary>
        /// Operations relating to rainfall
        /// </summary>
        /// <param name="request">Object request parameter</param>
        /// <returns></returns>
        [HttpGet("id/{stationId}/readings")]
        [SwaggerResponse(statusCode: 200, description: "A list of rainfall readings successfully retrieved", ContentTypes = new string[] { "application/json" })]
        [SwaggerResponse(statusCode: 400, description: "Invalid request",  ContentTypes = new string[] { "application/json" })]
        [SwaggerResponse(statusCode: 404, description: "No readings found for the specified stationId", Type = typeof(IEnumerable<StationResponse>), ContentTypes = new string[] { "application/json" })]
        [SwaggerResponse(statusCode: 500, description: "Internal server error", ContentTypes = new string[] { "application/json" })]

        public async Task<IActionResult> GetStationReadingAsync(StationRequestDto request)
        {
            var data = await _stationService.GetStationReadingAsync(request.stationId, request.Count);
            if (data.Any())
                return Ok(data);

            else
                return BadRequest();
        }
    }
}
