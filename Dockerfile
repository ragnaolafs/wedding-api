# Use the official .NET Core SDK as a parent image
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /

# Copy the project file and restore any dependencies (use .csproj for the project name)
COPY *.csproj ./
RUN dotnet restore

# Copy the rest of the application code
COPY . .

# Publish the application
RUN dotnet publish -c Release -o out

# Build the runtime image
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
WORKDIR /
COPY --from=build /out ./

# Expose the port your application will run on
EXPOSE 80

# Start the application
ENTRYPOINT ["dotnet", "wedding.dll"]