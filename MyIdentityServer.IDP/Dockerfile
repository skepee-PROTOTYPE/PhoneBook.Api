#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 950
EXPOSE 442

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["MyIdentityServer.IDP/MyIdentity.csproj", "MyIdentityServer.IDP/"]
RUN dotnet restore "MyIdentityServer.IDP/MyIdentity.csproj"
COPY . .
WORKDIR "/src/MyIdentityServer.IDP"
RUN dotnet build "MyIdentity.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MyIdentity.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MyIdentity.dll"]