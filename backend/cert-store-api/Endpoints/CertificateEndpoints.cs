using cert_store_api.Data;

namespace cert_store_api.Endpoints;

public static class CertificateEndpoints
{
    // Registers the minimal API endpoints related to certificate operations.
    public static void MapCertificateEndpoints(this WebApplication app)
    {
        // Simple health check endpoint to verify that the API is running.
        app.MapGet("/api/health", () =>
        {
            return Results.Ok(new { status = "ok" });
        })
        .WithName("GetHealth");

        // Returns sample root certificate data.
        app.MapGet("/api/root-certificates", () =>
        {
            return Results.Ok(SampleData.GetRootCertificates());
        })
        .WithName("GetRootCertificates");

        // Returns sample user certificate data.
        app.MapGet("/api/user-certificates", () =>
        {
            return Results.Ok(SampleData.GetUserCertificates());
        })
        .WithName("GetUserCertificates");
    }
}