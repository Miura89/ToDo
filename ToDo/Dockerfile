# Imagem base com runtime ASP.NET Core
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

# Imagem de build com o SDK
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["ToDo/ToDo.csproj", "ToDo/"]
RUN dotnet restore "ToDo/ToDo.csproj"
COPY . .
WORKDIR "/src/ToDo"
RUN dotnet build "ToDo.csproj" -c Release -o /app/build

# Imagem de publicação
FROM build AS publish
RUN dotnet publish "ToDo.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Imagem final com runtime ASP.NET Core
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ToDo.dll"]
