FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["dotnet-data-seed-docker-compose/dotnet-data-seed-docker-compose.csproj", "dotnet-data-seed-docker-compose/"]
RUN dotnet restore "dotnet-data-seed-docker-compose/dotnet-data-seed-docker-compose.csproj"
COPY . .
WORKDIR "/src/dotnet-data-seed-docker-compose"
RUN dotnet build "dotnet-data-seed-docker-compose.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "dotnet-data-seed-docker-compose.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "dotnet-data-seed-docker-compose.dll"]
