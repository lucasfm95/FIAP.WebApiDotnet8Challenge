using System.Net.Mime;
using System.Text.Json;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

namespace FIAP.WebApiDotnet8Challenge.WebAPI.Configurations;

internal static class HealthcheckConfig
{
    internal static void UseHealthcheck(this WebApplication app)
    {
        app.MapHealthChecks("/HealthCheck",
            new HealthCheckOptions
            {
                ResponseWriter = async (context, report) =>
                {
                    var result = JsonSerializer.Serialize(
                        new
                        {
                            currentTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                            statusApplication = report.Status.ToString(),
                            //mongoDbStatus = report.Entries.Values.FirstOrDefault().Status.ToString(),
                        });

                    context.Response.ContentType = MediaTypeNames.Application.Json;
                    await context.Response.WriteAsync(result);
                }
            });
    }
}