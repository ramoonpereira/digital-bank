FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build-env
WORKDIR /app
EXPOSE 80

WORKDIR /src

COPY DigitalBank.Api.Adm.Transaction/DigitalBank.Api.Adm.Transaction.csproj DigitalBank.Api.Adm.Transaction/
COPY DigitalBank.Api.Adm.Transaction.Business/DigitalBank.Api.Adm.Transaction.Business.csproj DigitalBank.Api.Adm.Transaction.Business/
COPY DigitalBank.Api.Adm.Transaction.Repository/DigitalBank.Api.Adm.Transaction.Repository.csproj DigitalBank.Api.Adm.Transaction.Repository/
COPY DigitalBank.Api.Adm.Transaction.Security/DigitalBank.Api.Adm.Transaction.Security.csproj DigitalBank.Api.Adm.Transaction.Security/

COPY . .

RUN dotnet restore

WORKDIR /src/DigitalBank.Api.Adm.Transaction


FROM build AS publish
RUN dotnet publish DigitalBank.Api.Adm.Transaction.csproj -c Release -o /app


FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "DigitalBank.Api.Adm.Transaction.dll"]