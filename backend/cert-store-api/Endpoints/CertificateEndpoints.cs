using cert_store_api.Services;
using MongoDB.Driver;

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

        // Returns root certificate data from MongoDB.
        app.MapGet("/api/root-certificates", async (MongoDbService mongoDbService) =>
        {
            var rootCertificates = await mongoDbService.RootCertificates
                .Find(_ => true)
                .ToListAsync();

            return Results.Ok(rootCertificates);
        })
        .WithName("GetRootCertificates");

        // Returns user certificate data from MongoDB.
        app.MapGet("/api/user-certificates", async (MongoDbService mongoDbService) =>
        {
            var userCertificates = await mongoDbService.UserCertificates
                .Find(_ => true)
                .ToListAsync();

            return Results.Ok(userCertificates);
        })
        .WithName("GetUserCertificates");

    }
}


        