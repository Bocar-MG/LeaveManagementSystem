FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app

ENV ASPNETCORE_HTTP_PORTS=5001
EXPOSE 5001


FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ManagementSystem.WebApi/ManagementSystem.WebApi.csproj", "ManagementSystem.WebApi/"]
COPY ["ManagementSystem.Application/ManagementSystem.Application.csproj", "ManagementSystem.Application/"]
COPY ["ManagementSystem.Contracts/ManagementSystem.Contracts.csproj", "ManagementSystem.Contracts/"]
COPY ["ManagementSystem.Domain/ManagementSystem.Domain.csproj", "ManagementSystem.Domain/"]
COPY ["ManagementSystem.Infrastructure/ManagementSystem.Infrastructure.csproj", "ManagementSystem.Infrastructure/"]
RUN dotnet restore "ManagementSystem.WebApi/ManagementSystem.WebApi.csproj"
COPY . .
WORKDIR "/src/ManagementSystem.WebApi"
RUN dotnet build "ManagementSystem.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "ManagementSystem.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ManagementSystem.WebApi.dll"]

