﻿FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["iOSClub.OJBlazor/iOSClub.OJBlazor.csproj", "iOSClub.OJBlazor/"]
RUN dotnet restore "iOSClub.OJBlazor/iOSClub.OJBlazor.csproj"
COPY . .
WORKDIR "/src/iOSClub.OJBlazor"
RUN dotnet build "iOSClub.OJBlazor.csproj" -c Release -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "iOSClub.OJBlazor.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:7.0  AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "iOSClub.OJBlazor.dll"]