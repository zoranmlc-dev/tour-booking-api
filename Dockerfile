# Build stage
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Copy project files
COPY src/TourBooking.Api/*.csproj src/TourBooking.Api/
COPY src/TourBooking.Domain/*.csproj src/TourBooking.Domain/
COPY src/TourBooking.Infrastructure/*.csproj src/TourBooking.Infrastructure/

# Copy rest of source
COPY src/ ./src/

# Restore
RUN dotnet restore src/TourBooking.Api/TourBooking.Api.csproj

# Publish API
WORKDIR /src/src/TourBooking.Api
RUN dotnet publish -c Release -o /app/out --no-restore

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:10.0
WORKDIR /app

ENV ASPNETCORE_URLS=http://+:5000

COPY --from=build /app/out .

EXPOSE 5000
ENTRYPOINT ["dotnet", "TourBooking.Api.dll"]
