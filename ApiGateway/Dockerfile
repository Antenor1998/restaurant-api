# Fase 1: Construcción
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiar archivos .csproj y restaurar dependencias
COPY ./ApiGateway/ApiGateway.csproj ./ApiGateway/
RUN dotnet restore ./ApiGateway/ApiGateway.csproj

# Copiar el resto del código fuente
COPY ./ApiGateway/ ./ApiGateway/

# Compilar y publicar
WORKDIR /src/ApiGateway
RUN dotnet publish -c Release -o /app/publish

# Fase 2: Ejecución
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .
EXPOSE 5000
ENTRYPOINT ["dotnet", "ApiGateway.dll"]
