using cert_store_api.Models;
using cert_store_api.Data;

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

app.MapGet("/api/health", () =>
{
    return Results.Ok(new { status = "ok" });
})
.WithName("GetHealth");

app.MapGet("/api/root-certificates", () =>
{
    return Results.Ok(SampleData.GetRootCertificates());
})
.WithName("GetRootCertificates");

app.MapGet("/api/user-certificates", () =>
{
    return Results.Ok(SampleData.GetUserCertificates());
})
.WithName("GetUserCertificates");

app.Run();
