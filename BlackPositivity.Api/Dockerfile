#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
EXPOSE 80
EXPOSE 443

COPY . .
RUN dotnet restore 

WORKDIR "/src/BlackPositivity.Api"
RUN dotnet build -c Release -o /app/build

FROM build AS publish
RUN dotnet publish -c Release -o /app/publish

FROM build AS final

COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BlackPositivity.Api.dll"]