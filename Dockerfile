FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 5000

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["tfou.csproj", "."]
RUN dotnet restore "./tfou.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "tfou.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "tfou.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "tfou.dll"]
