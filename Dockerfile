FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /app

# Direct root se restore
COPY SportsManagementApp.csproj ./
RUN dotnet restore SportsManagementApp.csproj

# Baaki code copy
COPY . .

RUN dotnet publish SportsManagementApp.csproj -c Release -o /out

FROM mcr.microsoft.com/dotnet/aspnet:10.0
WORKDIR /app

COPY --from=build /out .

ENV ASPNETCORE_ENVIRONMENT=Production
ENV ASPNETCORE_URLS=http://+:8080

ENTRYPOINT ["dotnet", "SportsManagementApp.dll"]