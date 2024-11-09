# Fase 1: Construcción
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiar el archivo .csproj y restaurar las dependencias
COPY src/Services/TenantService/TenantService.API/TenantService.API.csproj /src/Services/TenantService/TenantService.API/
RUN dotnet restore /src/Services/TenantService/TenantService.API/TenantService.API.csproj

# Copiar todo el código fuente al contenedor
COPY src/ /src/

# Establecer el directorio de trabajo
WORKDIR /src/Services/TenantService/TenantService.API

# Compilar y publicar la aplicación en el directorio /app/publish
RUN dotnet publish -c Release -o /app/publish

# Fase 2: Ejecución
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

# Exponer el puerto en el que se ejecutará la aplicación

# Instalar curl para depuración
RUN apt-get update && apt-get install -y curl
EXPOSE 5001

# Ejecutar la aplicación
ENTRYPOINT ["dotnet", "TenantService.API.dll"]
