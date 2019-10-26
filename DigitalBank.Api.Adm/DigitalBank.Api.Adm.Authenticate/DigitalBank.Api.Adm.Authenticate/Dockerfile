FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["DigitalBank.Api.Adm.Authenticate/DigitalBank.Api.Adm.Authenticate.csproj", "DigitalBank.Api.Adm.Authenticate/"]
COPY ["DigitalBank.Api.Adm.Authenticate.Security/DigitalBank.Api.Adm.Authenticate.Security.csproj", "DigitalBank.Api.Adm.Authenticate.Security/"]
COPY ["DigitalBank.Api.Adm.Authenticate.Repository/DigitalBank.Api.Adm.Authenticate.Repository.csproj", "DigitalBank.Api.Adm.Authenticate.Repository/"]
COPY ["DigitalBank.Api.Adm.Authenticate.Business/DigitalBank.Api.Adm.Authenticate.Business.csproj", "DigitalBank.Api.Adm.Authenticate.Business/"]
RUN dotnet restore "DigitalBank.Api.Adm.Authenticate/DigitalBank.Api.Adm.Authenticate.csproj"
COPY . .
WORKDIR "/src/DigitalBank.Api.Adm.Authenticate"
RUN dotnet build "DigitalBank.Api.Adm.Authenticate.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DigitalBank.Api.Adm.Authenticate.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DigitalBank.Api.Adm.Authenticate.dll"]