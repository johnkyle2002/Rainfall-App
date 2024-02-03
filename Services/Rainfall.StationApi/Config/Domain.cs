using Microsoft.Extensions.Options;
using Rainfall.ApiHelper.Interface;
using Rainfall.DataTransferObject;

namespace Rainfall.StationApi.Config
{
    /// <summary>
    /// 
    /// </summary>
    public class Domain : IDomain
    {
        private readonly string _baseUrl;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public Domain(IOptions<RainfallAppOptionDto> options)
        {
            if (string.IsNullOrWhiteSpace(options.Value.BaseUrl))
                throw new ArgumentNullException("Rainfall base url is empty");

            _baseUrl = options.Value.BaseUrl;
        }

        /// <summary>
        /// Default value for credential and other reuqirement for http header
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Dictionary<string, string>? Header()
        {
            return default;
        }

        /// <summary>
        /// Get rainfall base url from appsettings
        /// </summary>
        /// <returns></returns>
        public string BaseUrl() => _baseUrl;
    }
}
