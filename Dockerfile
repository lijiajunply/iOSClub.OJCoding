FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["iOSClub.OJBlazor/iOSClub.OJBlazor.csproj", "iOSClub.OJBlazor/"]
COPY ["OJBlazor.Share/OJBlazor.Share.csproj", "OJBlazor.Share/"]
RUN dotnet restore "iOSClub.OJBlazor/iOSClub.OJBlazor.csproj"
COPY . .
WORKDIR "/src/iOSClub.OJBlazor"
RUN dotnet build "iOSClub.OJBlazor.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "iOSClub.OJBlazor.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# 基于 ubuntu:20.04 镜像
FROM ubuntu:20.04
# 设置时区为上海
ENV TZ=Asia/Shanghai
RUN ln -snf /usr/share/zoneinfo/$TZ /etc/localtime && echo $TZ > /etc/timezone

# 更新软件源并安装一些必要的软件
RUN apt-get update && apt-get install -y \
    sudo \
    curl \
    wget \
    
# 安装 python3 和 pip
RUN apt-get install -y python3 python3-pip
# 安装 flask
RUN pip3 install flask
# 安装 mysql
RUN apt-get install -y mysql-server mysql-client
# 安装 git
RUN apt-get install -y git

FROM mcr.microsoft.com/dotnet/sdk:7.0  AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "iOSClub.OJBlazor.dll"]