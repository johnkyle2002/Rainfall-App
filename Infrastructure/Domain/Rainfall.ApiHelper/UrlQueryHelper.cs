using Newtonsoft.Json;
using System.Reflection;

namespace Rainfall.ApiHelper
{
    public static class UrlQueryHelper
    {
        /// <summary>
        /// Helper to translate class field value to url query parameter
        /// </summary>
        /// <typeparam name="TSource">class</typeparam>
        /// <param name="source">Initialized entity class</param>
        /// <returns></returns>
        public static string ToParameterString<TSource>(this TSource source)
            where TSource : class
        {
            if (source == null)
                return string.Empty;

            var sourceProperties = source.GetType().GetProperties();

            if (sourceProperties is null)
                return string.Empty;

            var p = sourceProperties.Where(w =>
            {
                var jsonProp = w.GetCustomAttribute<JsonIgnoreAttribute>();              
                return (jsonProp != null) ? false: true;
            }).Select(s =>
            {
                var name = s.GetCustomAttribute<JsonPropertyAttribute>()?.PropertyName ?? s.Name;
                return new
                {
                    key = name,
                    value = source.GetType().GetProperty(s.Name)?.GetValue(source, null)?.ToString()
                };
            })
            .Where(w => !string.IsNullOrWhiteSpace(w.value))
            .ToList();

            if (p.Any())
                return "?" + string.Join("&", p.Select(s => $"{s.key}={s.value}"));

            return string.Empty;
        }
    }
}
