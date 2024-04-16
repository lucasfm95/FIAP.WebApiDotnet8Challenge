using System.Text.Json;
using System.Text.Json.Serialization;

namespace FIAP.WebApiDotnet8Challenge.WebAPI.Configurations;

internal static class JsonConfig
{
    internal static void JsonConfigation(this IMvcBuilder mvcBuilder) =>
        mvcBuilder.AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
            options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
        });
}