FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["BUNKR.Primary/BUNKR.Primary.csproj", "BUNKR.Primary/"]
RUN dotnet restore "BUNKR.Primary/BUNKR.Primary.csproj"
COPY . .
WORKDIR "/src/BUNKR.Primary"
RUN dotnet build "BUNKR.Primary.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BUNKR.Primary.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BUNKR.Primary.dll"]
