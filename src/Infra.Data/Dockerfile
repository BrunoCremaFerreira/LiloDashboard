FROM mcr.microsoft.com/dotnet/sdk:6.0 AS dotnet-ef
WORKDIR /src
COPY ["API/LiloDash.API.csproj", "API/"]
RUN dotnet restore "API/LiloDash.API.csproj"
COPY . .
WORKDIR "/src/Infra.Data"
ARG DB_CONNECTION_STRING="Data Source=(LocalDb)\MSSQLLocalDB;Database=lilo-db"
RUN dotnet tool install --global dotnet-ef
ENV PATH="$PATH:/root/.dotnet/tools"
RUN dotnet ef migrations bundle --self-contained -r linux-x64 --force

FROM mcr.microsoft.com/dotnet/aspnet AS migrations-run
ENV DB_CONNECTION_STRING=""
WORKDIR /app
COPY --from=dotnet-ef /src/Infra.Data/efbundle .
ENTRYPOINT ["ef-bundle"]