FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["BUNKR.Secondary/BUNKR.Secondary.csproj", "BUNKR.Secondary/"]
RUN dotnet restore "BUNKR.Secondary/BUNKR.Secondary.csproj"
COPY . .
WORKDIR "/src/BUNKR.Secondary"
RUN dotnet build "BUNKR.Secondary.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BUNKR.Secondary.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BUNKR.Secondary.dll"]
