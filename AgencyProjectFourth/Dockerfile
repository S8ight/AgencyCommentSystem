FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["AgencyProjectFourth/AgencyProjectFourth.csproj", "AgencyProjectFourth/"]
RUN dotnet restore "AgencyProjectFourth/AgencyProjectFourth.csproj"
COPY . .
WORKDIR "/src/AgencyProjectFourth"
RUN dotnet build "AgencyProjectFourth.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AgencyProjectFourth.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AgencyProjectFourth.dll"]
