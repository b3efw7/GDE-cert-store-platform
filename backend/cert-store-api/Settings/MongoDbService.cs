using cert_store_api.Models;
using cert_store_api.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace cert_store_api.Services;

public class MongoDbService
{
    public IMongoCollection<RootCertificate> RootCertificates { get; }

    public IMongoCollection<UserCertificate> UserCertificates { get; }

    public MongoDbService(IOptions<MongoDbSettings> mongoDbSettings)
    {
        // Reads MongoDB configuration from appsettings.
        var settings = mongoDbSettings.Value;

        // Creates the MongoDB client and opens the target database.
        var mongoClient = new MongoClient(settings.ConnectionString);
        var mongoDatabase = mongoClient.GetDatabase(settings.DatabaseName);

        // Gets the collection used for root certificate documents.
        RootCertificates = mongoDatabase.GetCollection<RootCertificate>(
            settings.RootCertificatesCollectionName);

        // Gets the collection used for user certificate documents.
        UserCertificates = mongoDatabase.GetCollection<UserCertificate>(
            settings.UserCertificatesCollectionName);
    }
}