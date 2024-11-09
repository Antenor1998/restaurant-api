# Fase 1: Construcción
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiar el archivo .csproj y restaurar dependencias
COPY ./src/Services/TenantService/TenantService.API/TenantService.API.csproj ./Services/TenantService/TenantService.API/
RUN dotnet restore ./Services/TenantService/TenantService.API/TenantService.API.csproj

# Copiar el resto del código fuente al contenedor
COPY ./src/ /src/

# Establecer el directorio de trabajo y compilar la aplicación
WORKDIR /src/Services/TenantService/TenantService.API
RUN dotnet publish -c Release -o /app/publish --no-restore

# Fase 2: Ejecución
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

# Exponer el puerto
EXPOSE 5001

# Ejecutar la aplicación
ENTRYPOINT ["dotnet", "TenantService.API.dll"]
