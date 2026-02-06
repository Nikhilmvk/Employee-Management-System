# Use the official ASP.NET runtime image as the base image for running the app
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

# Use the official .NET SDK image for building the app
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

# Copy your project file and restore dependencies
COPY ["DotNetSqlJenkins.csproj", "./"]
RUN dotnet restore "./DotNetSqlJenkins.csproj"

# Copy everything else and build the project
COPY . .
RUN dotnet publish "DotNetSqlJenkins.csproj" -c Release -o /app/publish

# Build runtime image
FROM base AS final
WORKDIR /app

# Copy the published output from the build image
COPY --from=build /app/publish .

# Specify the entrypoint for the container
ENTRYPOINT ["dotnet", "DotNetSqlJenkins.dll"]
