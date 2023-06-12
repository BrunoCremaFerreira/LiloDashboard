FROM mcr.microsoft.com/dotnet/sdk:6.0 AS run-migration
WORKDIR /src
COPY ["API/LiloDash.API.csproj", "API/"]
RUN dotnet restore "API/LiloDash.API.csproj"

COPY . .
WORKDIR "/src/Infra.Data"
ENV DB_CONNECTION_STRING=""
RUN dotnet tool install --global dotnet-ef --version 6.*
ENTRYPOINT ["dotnet", "ef",  "database", "update"]