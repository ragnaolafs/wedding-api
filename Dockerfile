FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["*.csproj", "/"]
RUN dotnet restore "/wedding/wedding.csproj"
COPY . .
WORKDIR "/src/wedding"
RUN dotnet build "wedding.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "wedding.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "wedding.dll"]
