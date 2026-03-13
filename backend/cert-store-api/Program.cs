using cert_store_api.Models;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapGet("/api/root-certificates", () =>
{
    var rootCertificates = new List<RootCertificate>
    {
        new RootCertificate
        {
            Id = Guid.NewGuid(),
            CommonName = "GDE Root CA",
            Subject = "CN=GDE Root CA",
            Issuer = "CN=GDE Root CA",
            ValidFrom = DateTime.UtcNow,
            ValidTo = DateTime.UtcNow.AddYears(5),
            Status = "Active"
        }
    };

    return Results.Ok(rootCertificates);
})
.WithName("GetRootCertificates");

app.Run();

