using cert_store_api.Endpoints;
using cert_store_api.Settings;
using cert_store_api.Services;
using cert_store_api.Models;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Binds MongoDB settings from configuration.
builder.Services.Configure<MongoDbSettings>(
    builder.Configuration.GetSection("MongoDb"));

// Registers the MongoDB service for dependency injection.
builder.Services.AddSingleton<MongoDbService>();
    
// Allows the Angular frontend to call the backend during local development.
builder.Services.AddCors(options =>
{
    options.AddPolicy("FrontendPolicy", policy =>
    {
        policy.WithOrigins("http://localhost:4200")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

// Enables the local CORS policy for the Angular frontend.
app.UseCors("FrontendPolicy");


// Seeds the MongoDB collections with default certificate data if they are empty.
using (var scope = app.Services.CreateScope())
{
    var mongoDbService = scope.ServiceProvider.GetRequiredService<MongoDbService>();

    var rootCertificateCount = mongoDbService.RootCertificates
        .CountDocuments(Builders<RootCertificate>.Filter.Empty);

    if (rootCertificateCount == 0)
    {
        mongoDbService.RootCertificates.InsertMany(new[]
        {
            new RootCertificate
            {
                Id = Guid.NewGuid().ToString(),
                CommonName = "GDE Root CA",
                Subject = "CN=GDE Root CA",
                Issuer = "CN=GDE Root CA",
                ValidFrom = DateTime.UtcNow,
                ValidTo = DateTime.UtcNow.AddYears(5),
                Status = "Active"
            },
            new RootCertificate
            {
                Id = Guid.NewGuid().ToString(),
                CommonName = "Training Root CA",
                Subject = "CN=Training Root CA",
                Issuer = "CN=Training Root CA",
                ValidFrom = DateTime.UtcNow.AddDays(-30),
                ValidTo = DateTime.UtcNow.AddYears(3),
                Status = "Active"
            },
            new RootCertificate
            {
                Id = Guid.NewGuid().ToString(),
                CommonName = "Legacy Root CA",
                Subject = "CN=Legacy Root CA",
                Issuer = "CN=Legacy Root CA",
                ValidFrom = DateTime.UtcNow.AddYears(-2),
                ValidTo = DateTime.UtcNow.AddMonths(6),
                Status = "Expiring"
            }
        });
    }

    var userCertificateCount = mongoDbService.UserCertificates
        .CountDocuments(Builders<UserCertificate>.Filter.Empty);

    if (userCertificateCount == 0)
    {
        mongoDbService.UserCertificates.InsertMany(new[]
        {
            new UserCertificate
            {
                Id = Guid.NewGuid().ToString(),
                CommonName = "GDE Student Certificate",
                Subject = "CN=GDE Student",
                Issuer = "CN=GDE Root CA",
                Email = "student@neptun.gde.hu",
                ValidFrom = DateTime.UtcNow,
                ValidTo = DateTime.UtcNow.AddYears(2),
                Status = "Issued"
            },
            new UserCertificate
            {
                Id = Guid.NewGuid().ToString(),
                CommonName = "Training User Certificate",
                Subject = "CN=Training User",
                Issuer = "CN=Training Root CA",
                Email = "training.user@gde.hu",
                ValidFrom = DateTime.UtcNow.AddDays(-10),
                ValidTo = DateTime.UtcNow.AddYears(1),
                Status = "Issued"
            },
            new UserCertificate
            {
                Id = Guid.NewGuid().ToString(),
                CommonName = "Legacy Student Certificate",
                Subject = "CN=Legacy Student",
                Issuer = "CN=Legacy Root CA",
                Email = "legacy.student@gde.hu",
                ValidFrom = DateTime.UtcNow.AddYears(-1),
                ValidTo = DateTime.UtcNow.AddMonths(3),
                Status = "Expiring"
            }
        });
    }
}

// Register certificate-related API endpoints.
app.MapCertificateEndpoints();

app.Run();