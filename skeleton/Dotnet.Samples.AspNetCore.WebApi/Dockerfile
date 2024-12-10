# Use the official .NET 8 SDK image as the build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0-alpine AS build-env

WORKDIR /Dotnet.Samples.AspNetCore.WebApi

# Copy the csproj and restore dependencies
COPY *.csproj ./
RUN dotnet restore

# Copy the rest of the project and build the image
COPY . .
RUN dotnet publish -c Release -o out

# Use the official .NET 8 ASP.NET Core runtime image as the runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine

WORKDIR /Dotnet.Samples.AspNetCore.WebApi

# Copy the published application from the build stage
COPY --from=build-env /Dotnet.Samples.AspNetCore.WebApi/out .

# Expose the port used by the web API
EXPOSE 8080

# Set the entry point to the published application
ENTRYPOINT ["dotnet", "Dotnet.Samples.AspNetCore.WebApi.dll"]