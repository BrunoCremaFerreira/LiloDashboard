FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["API/LiloDash.API.csproj", "API/"]
RUN dotnet restore "API/LiloDash.API.csproj"
COPY . .
WORKDIR "/src/API"
RUN dotnet build "LiloDash.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LiloDash.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LiloDash.API.dll"]
