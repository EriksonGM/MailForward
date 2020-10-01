#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/MailForward.UI/MailForward.UI.csproj", "src/MailForward.UI/"]
COPY ["src/MailForward.Data/MailForward.Data.csproj", "src/MailForward.Data/"]
RUN dotnet restore "src/MailForward.UI/MailForward.UI.csproj"
COPY . .
WORKDIR "/src/src/MailForward.UI"
RUN dotnet build "MailForward.UI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MailForward.UI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MailForward.UI.dll"]