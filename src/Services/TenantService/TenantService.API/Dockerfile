# Fase 1: Construcción
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Limpiar la caché de NuGet y configurar el feed
RUN dotnet nuget locals --clear all


# Copiar archivos .csproj y restaurar dependencias
COPY src/Services/SharedKernel/SharedKernel.lib/SharedKernel.lib.csproj ./Services/SharedKernel/SharedKernel.lib/
RUN dotnet restore ./Services/SharedKernel/SharedKernel.lib/SharedKernel.lib.csproj

COPY src/Services/TenantService/TenantService.API/TenantService.API.csproj ./Services/TenantService/TenantService.API/
RUN dotnet restore ./Services/TenantService/TenantService.API/TenantService.API.csproj --force-evaluate

# Copiar el resto del código fuente
COPY src/ /src/

# Compilar y publicar
WORKDIR /src/Services/TenantService/TenantService.API
RUN dotnet build -c Release --no-restore
RUN dotnet publish -c Release -o /app/publish --no-restore

# Fase 2: Ejecución
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .
EXPOSE 5001
ENTRYPOINT ["dotnet", "TenantService.API.dll"]
