# Fase 1: Construcción
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiar solo los archivos .csproj y restaurar las dependencias primero para aprovechar la caché de Docker
COPY src/Services/AnalyticsService/AnalyticsService.API/AnalyticsService.API.csproj /src/Services/AnalyticsService/AnalyticsService.API/
RUN dotnet restore /src/Services/AnalyticsService/AnalyticsService.API/AnalyticsService.API.csproj

# Copiar el resto del código fuente al contenedor
COPY src/ /src/

# Establecer el directorio de trabajo y compilar la aplicación
WORKDIR /src/Services/AnalyticsService/AnalyticsService.API
RUN dotnet publish -c Release -o /app/publish --no-restore

# Fase 2: Ejecución
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# Copiar los archivos publicados desde la fase anterior
COPY --from=build /app/publish .

# Instalar curl solo si es necesario (mejor para la depuración)
RUN apt-get update && apt-get install -y --no-install-recommends curl && apt-get clean && rm -rf /var/lib/apt/lists/*

# Exponer el puerto en el que se ejecutará la aplicación
EXPOSE 5003

# Establecer la variable de entorno para el entorno de producción
ENV ASPNETCORE_ENVIRONMENT=Production

# Ejecutar la aplicación
ENTRYPOINT ["dotnet", "AnalyticsService.API.dll"]
