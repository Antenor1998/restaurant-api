# Fase 1: Construcción
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

RUN dotnet nuget locals --clear all

# Copiar solo los archivos .csproj y restaurar las dependencias primero para aprovechar la caché de Docker
COPY ./src/Services/AnalyticsService/AnalyticsService.API/AnalyticsService.API.csproj ./src/Services/AnalyticsService/AnalyticsService.API/
RUN dotnet restore ./src/Services/AnalyticsService/AnalyticsService.API/AnalyticsService.API.csproj

COPY ./src/Services/AnalyticsService/AnalyticsService.API/ ./src/Services/AnalyticsService/AnalyticsService.API/

# Copiar el resto del código fuente al contenedor
COPY src/ /src/

# Establecer el directorio de trabajo y compilar la aplicación
WORKDIR /src/Services/AnalyticsService/AnalyticsService.API
RUN dotnet publish -c Release -o /app/publish

# Fase 2: Ejecución
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .
# Instalar curl solo si es necesario (mejor para la depuración)
# RUN apt-get update && apt-get install -y --no-install-recommends curl && apt-get clean && rm -rf /var/lib/apt/lists/*
EXPOSE 5003
ENTRYPOINT ["dotnet", "AnalyticsService.API.dll"]
