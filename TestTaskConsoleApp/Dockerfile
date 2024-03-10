FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

COPY ["patients.json", "/app"]

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["TestTaskConsoleApp.csproj", "TestTaskConsoleApp/"]

RUN dotnet restore "TestTaskConsoleApp/TestTaskConsoleApp.csproj"
COPY . .
RUN dotnet build "TestTaskConsoleApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TestTaskConsoleApp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TestTaskConsoleApp.dll"]