FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# copia o csproj direto pra raiz do container
COPY ["resting_dotnet.csproj", "./"]

# restore correto
RUN dotnet restore "resting_dotnet.csproj"

# copia tudo
COPY . .

# build correto
RUN dotnet build "resting_dotnet.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
RUN dotnet publish "resting_dotnet.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "resting_dotnet.dll"]