FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["TestTaskApi.csproj", "TestTaskApi/"]
RUN dotnet restore "TestTaskApi/TestTaskApi.csproj"
WORKDIR "/src/TestTaskApi"
COPY . .
RUN dotnet build "./TestTaskApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "./TestTaskApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TestTaskApi.dll"]