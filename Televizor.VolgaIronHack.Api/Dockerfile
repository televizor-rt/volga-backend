FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Televizor.VolgaIronHack.Api/Televizor.VolgaIronHack.Api.csproj", "Televizor.VolgaIronHack.Api/"]
RUN dotnet restore "Televizor.VolgaIronHack.Api/Televizor.VolgaIronHack.Api.csproj"
COPY . .
WORKDIR "/src/Televizor.VolgaIronHack.Api"
RUN dotnet build "Televizor.VolgaIronHack.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Televizor.VolgaIronHack.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Televizor.VolgaIronHack.Api.dll"]
