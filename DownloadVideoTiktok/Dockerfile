#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["DownloadVideoTiktok/DownloadVideoTiktok.csproj", "DownloadVideoTiktok/"]
RUN dotnet restore "DownloadVideoTiktok/DownloadVideoTiktok.csproj"
COPY . .
WORKDIR "/src/DownloadVideoTiktok"
RUN apt-get update -yq 
RUN apt-get install curl gnupg -yq 
RUN curl -sL https://deb.nodesource.com/setup_13.x | bash -
RUN apt-get install -y nodejs
RUN npm install -g gulp
RUN npm install gulp
RUN dotnet build "DownloadVideoTiktok.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DownloadVideoTiktok.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DownloadVideoTiktok.dll"]