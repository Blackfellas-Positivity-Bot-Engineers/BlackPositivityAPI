#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["BlackPositivity.Api/BlackPositivity.Api.csproj", "BlackPositivity.Api/"]
COPY ["BlackPositivity.Application/BlackPositivity.Application.csproj", "BlackPositivity.Application/"]
COPY ["BlackPositivity.Domain/BlackPositivity.Domain.csproj", "BlackPositivity.Domain/"]
COPY ["BlackPositivity.Infrastructure/BlackPositivity.Infrastructure.csproj", "BlackPositivity.Infrastructure/"]
RUN dotnet restore "BlackPositivity.Api/BlackPositivity.Api.csproj"
COPY . .
WORKDIR "/src/BlackPositivity.Api"
RUN dotnet build "BlackPositivity.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BlackPositivity.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_ENVIRONMENT=${ASPNETCORE_ENVIRONMENT}
ENTRYPOINT ["dotnet", "BlackPositivity.Api.dll"]