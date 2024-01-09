#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["DevFreela.API/DevFreela.API.csproj", "DevFreela.API/"]
COPY ["DevFreela.Application/DevFreela.Application.csproj", "DevFreela.Application/"]
COPY ["DevFreela.Domain/DevFreela.Domain.csproj", "DevFreela.Domain/"]
COPY ["DevFreela.Infrastructure/DevFreela.Infrastructure.csproj", "DevFreela.Infrastructure/"]
RUN dotnet restore "./DevFreela.API/./DevFreela.API.csproj"
COPY . .
WORKDIR "/src/DevFreela.API"
RUN dotnet build "./DevFreela.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./DevFreela.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DevFreela.API.dll"]