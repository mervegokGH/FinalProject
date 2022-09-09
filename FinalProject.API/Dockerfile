#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["FinalProject.API/FinalProject.API.csproj", "FinalProject.API/"]
RUN dotnet restore "FinalProject.API/FinalProject.API.csproj"
COPY . .
WORKDIR "/src/FinalProject.API"
RUN dotnet build "FinalProject.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FinalProject.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FinalProject.API.dll"]