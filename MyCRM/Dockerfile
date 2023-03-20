#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["MyCRM/MyCRM.csproj", "MyCRM/"]
RUN dotnet restore "MyCRM/MyCRM.csproj"
COPY . .
WORKDIR "/src/MyCRM"
RUN dotnet build "MyCRM.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MyCRM.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MyCRM.dll"]