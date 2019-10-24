FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["DigitalBank.Api.Pub.Authenticate/DigitalBank.Api.Pub.Authenticate.csproj", "DigitalBank.Api.Pub.Authenticate/"]
COPY ["DigitalBank.Api.Pub.Authenticate.Security/DigitalBank.Api.Pub.Authenticate.Security.csproj", "DigitalBank.Api.Pub.Authenticate.Security/"]
COPY ["DigitalBank.Api.Pub.Authenticate.Repository/DigitalBank.Api.Pub.Authenticate.Repository.csproj", "DigitalBank.Api.Pub.Authenticate.Repository/"]
COPY ["DigitalBank.Api.Pub.Authenticate.Business/DigitalBank.Api.Pub.Authenticate.Business.csproj", "DigitalBank.Api.Pub.Authenticate.Business/"]
RUN dotnet restore "DigitalBank.Api.Pub.Authenticate/DigitalBank.Api.Pub.Authenticate.csproj"
COPY . .
WORKDIR "/src/DigitalBank.Api.Pub.Authenticate"
RUN dotnet build "DigitalBank.Api.Pub.Authenticate.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DigitalBank.Api.Pub.Authenticate.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DigitalBank.Api.Pub.Authenticate.dll"]