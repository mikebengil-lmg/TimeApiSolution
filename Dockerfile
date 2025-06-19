# Use official .NET SDK image to build and publish
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy everything into /src
COPY . ./

# Change into project folder
WORKDIR /src/TimeApi

# Publish the project
RUN dotnet publish TimeApi.csproj -c Release -o /app/publish

# Use runtime image for final output
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .

# Expose the default port
EXPOSE 80

ENTRYPOINT ["dotnet", "TimeApi.dll"]