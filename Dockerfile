FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 4430 8080
ENV ASPNETCORE_URLS=https://*:443;http://*:80
# RUN dotnet dev-certs https

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["HydroPi.csproj", "./"]
RUN dotnet restore "HydroPi.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "HydroPi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HydroPi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HydroPi.dll"]
