FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build-env
WORKDIR /app
EXPOSE 80

WORKDIR /src

COPY DigitalBank.Api.Adm.Authenticate/DigitalBank.Api.Adm.Authenticate.csproj DigitalBank.Api.Adm.Authenticate/
COPY DigitalBank.Api.Adm.Authenticate.Business/DigitalBank.Api.Adm.Authenticate.Business.csproj DigitalBank.Api.Adm.Authenticate.Business/
COPY DigitalBank.Api.Adm.Authenticate.Repository/DigitalBank.Api.Adm.Authenticate.Repository.csproj DigitalBank.Api.Adm.Authenticate.Repository/
COPY DigitalBank.Api.Adm.Authenticate.Security/DigitalBank.Api.Adm.Authenticate.Security.csproj DigitalBank.Api.Adm.Authenticate.Security/

COPY . .

RUN dotnet restore

WORKDIR /src/DigitalBank.Api.Adm.Authenticate


FROM build AS publish
RUN dotnet publish DigitalBank.Api.Adm.Authenticate.csproj -c Release -o /app


FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "DigitalBank.Api.Adm.Authenticate.dll"]