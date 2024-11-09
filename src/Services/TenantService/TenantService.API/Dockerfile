
# Fase 1: Construcción
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Limpiar la caché de NuGet antes de restaurar
RUN dotnet nuget locals --clear all

# Copiar archivos .csproj y restaurar dependencias para SharedKernel primero
COPY src/Services/SharedKernel/SharedKernel.lib/SharedKernel.lib.csproj ./Services/SharedKernel/SharedKernel.lib/
RUN dotnet restore ./Services/SharedKernel/SharedKernel.lib/SharedKernel.lib.csproj

# Copiar archivos .csproj y restaurar dependencias para TenantService
COPY src/Services/TenantService/TenantService.API/TenantService.API.csproj ./Services/TenantService/TenantService.API/
RUN dotnet restore ./Services/TenantService/TenantService.API/TenantService.API.csproj

# Copiar todo el código fuente después de restaurar las dependencias
COPY src/ /src/

# Establecer el directorio de trabajo y compilar la aplicación
WORKDIR /src/Services/TenantService/TenantService.API
RUN dotnet build -c Release --no-restore
RUN dotnet publish -c Release -o /app/publish --no-restore

# Fase 2: Ejecución
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# Copiar los archivos publicados desde la fase de construcción
COPY --from=build /app/publish .

# Exponer el puerto
EXPOSE 5001

# Establecer la variable de entorno para producción
ENV ASPNETCORE_ENVIRONMENT=Production

# Ejecutar la aplicación
ENTRYPOINT ["dotnet", "TenantService.API.dll"]
