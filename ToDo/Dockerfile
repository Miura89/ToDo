
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
RUN apt-get update \
	&& apt-get install -y --no-install-recommends \
	clang zlib1g-dev
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ToDo/ToDo.csproj", "ToDo/"]
RUN dotnet restore "./ToDo/ToDo.csproj"
COPY . .
WORKDIR "/src/ToDo"
RUN dotnet build "./ToDo.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./ToDo.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=true

FROM mcr.microsoft.com/dotnet/runtime-deps:8.0 AS final
WORKDIR /app
EXPOSE 8080
COPY --from=publish /app/publish .
ENTRYPOINT ["./ToDo"]