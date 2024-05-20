FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /source
COPY ["src", "/source/"]
COPY ["/source/wedding.csproj", "/"]
RUN dotnet restore "/source/wedding.csproj"
COPY . .
WORKDIR /source
RUN dotnet build "/source/wedding.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "/source/wedding.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "wedding.dll"]
