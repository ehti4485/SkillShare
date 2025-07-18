FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["PakistaniTaskerPlatform.csproj", "./"]
RUN dotnet restore "./PakistaniTaskerPlatform.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "PakistaniTaskerPlatform.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PakistaniTaskerPlatform.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PakistaniTaskerPlatform.dll"]
