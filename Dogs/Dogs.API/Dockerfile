#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Dogs.API/Dogs.API.csproj", "Dogs.API/"]
COPY ["Dogs.Application/Dogs.Application.csproj", "Dogs.Application/"]
COPY ["Dogs.Domain/Dogs.Domain.csproj", "Dogs.Domain/"]
COPY ["Dogs.Infrastructure/Dogs.Infrastructure.csproj", "Dogs.Infrastructure/"]
RUN dotnet restore "Dogs.API/Dogs.API.csproj"
COPY . .
WORKDIR "/src/Dogs.API"
RUN dotnet build "Dogs.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Dogs.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Dogs.API.dll"]