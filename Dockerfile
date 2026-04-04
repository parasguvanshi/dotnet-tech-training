FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /app

# Sirf csproj copy karo
COPY SportsManagementApp/SportsManagementApp.csproj ./SportsManagementApp/
RUN dotnet restore SportsManagementApp/SportsManagementApp.csproj

# Ab baaki code copy karo
COPY . .

RUN dotnet publish SportsManagementApp/SportsManagementApp.csproj -c Release -o /out

FROM mcr.microsoft.com/dotnet/aspnet:10.0
WORKDIR /app

COPY --from=build /out .

ENV ASPNETCORE_ENVIRONMENT=Production
ENV ASPNETCORE_URLS=http://+:8080

ENTRYPOINT ["dotnet", "SportsManagementApp.dll"]