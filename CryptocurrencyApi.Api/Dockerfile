#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["CryptocurrencyApi.Api/CryptocurrencyApi.Api.csproj", "CryptocurrencyApi.Api/"]
COPY ["CryptocurrencyApi.Application/CryptocurrencyApi.Application.csproj", "CryptocurrencyApi.Application/"]
COPY ["CryptocurrencyApi.Domain/CryptocurrencyApi.Domain.csproj", "CryptocurrencyApi.Domain/"]
COPY ["CryptocurrencyApi.Infrastructure/CryptocurrencyApi.Infrastructure.csproj", "CryptocurrencyApi.Infrastructure/"]
RUN dotnet restore "CryptocurrencyApi.Api/CryptocurrencyApi.Api.csproj"
COPY . .
WORKDIR "/src/CryptocurrencyApi.Api"
RUN dotnet build "CryptocurrencyApi.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CryptocurrencyApi.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CryptocurrencyApi.Api.dll"]