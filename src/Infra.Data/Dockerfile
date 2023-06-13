FROM mcr.microsoft.com/dotnet/sdk:6.0 AS dotnet-ef
WORKDIR /src
COPY ["API/LiloDash.API.csproj", "API/"]
RUN dotnet restore "API/LiloDash.API.csproj"
COPY . .
WORKDIR "/src/Infra.Data"
ENV DB_CONNECTION_STRING=""
RUN dotnet tool install --global dotnet-ef
RUN ls -lah ~
ENV PATH="$PATH:/root/.dotnet/tools"

FROM dotnet-ef AS migrations-run
ENTRYPOINT ["dotnet-ef", "database", "update"]