# Build stage: compiles and publishes the ASP.NET Core application.
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copy project file first to allow better layer caching during restore.
COPY ["cert-store-api.csproj", "./"]
RUN dotnet restore "cert-store-api.csproj"

# Copy the remaining source files and publish the application.
COPY . .
RUN dotnet publish "cert-store-api.csproj" -c Release -o /app/publish

# Runtime stage: runs the published application with the ASP.NET runtime image.
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app

# Copy published output from the build stage.
COPY --from=build /app/publish .

# Exposes the HTTP port used by the containerized API.
EXPOSE 8080

# Starts the ASP.NET Core application inside the container.
ENTRYPOINT ["dotnet", "cert-store-api.dll"]