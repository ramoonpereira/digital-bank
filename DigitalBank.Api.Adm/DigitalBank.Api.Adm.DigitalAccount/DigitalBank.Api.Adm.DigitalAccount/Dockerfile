FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build-env
WORKDIR /app
EXPOSE 80

WORKDIR /src

COPY DigitalBank.Api.Adm.DigitalAccount/DigitalBank.Api.Adm.DigitalAccount.csproj DigitalBank.Api.Adm.DigitalAccount/
COPY DigitalBank.Api.Adm.DigitalAccount.Business/DigitalBank.Api.Adm.DigitalAccount.Business.csproj DigitalBank.Api.Adm.DigitalAccount.Business/
COPY DigitalBank.Api.Adm.DigitalAccount.Repository/DigitalBank.Api.Adm.DigitalAccount.Repository.csproj DigitalBank.Api.Adm.DigitalAccount.Repository/
COPY DigitalBank.Api.Adm.DigitalAccount.Security/DigitalBank.Api.Adm.DigitalAccount.Security.csproj DigitalBank.Api.Adm.DigitalAccount.Security/

COPY . .

RUN dotnet restore

WORKDIR /src/DigitalBank.Api.Adm.DigitalAccount


FROM build AS publish
RUN dotnet publish DigitalBank.Api.Adm.DigitalAccount.csproj -c Release -o /app


FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "DigitalBank.Api.Adm.DigitalAccount.dll"]