#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["SalesProducts.Api/SalesProducts.Api.csproj", "SalesProducts.Api/"]
COPY ["SalesProducts.Core/SalesProducts.Core.csproj", "SalesProducts.Core/"]
COPY ["SalesProducts.Infrastructure/SalesProducts.Infrastructure.csproj", "SalesProducts.Infrastructure/"]
RUN dotnet restore "SalesProducts.Api/SalesProducts.Api.csproj"
COPY . .
WORKDIR "/src/SalesProducts.Api"
RUN dotnet build "SalesProducts.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SalesProducts.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SalesProducts.Api.dll"]