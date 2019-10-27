FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build-env
WORKDIR /app
EXPOSE 80

WORKDIR /src

COPY DigitalBank.Api.Pub.Transaction/DigitalBank.Api.Pub.Transaction.csproj DigitalBank.Api.Pub.Transaction/
COPY DigitalBank.Api.Pub.Transaction.Business/DigitalBank.Api.Pub.Transaction.Business.csproj DigitalBank.Api.Pub.Transaction.Business/
COPY DigitalBank.Api.Pub.Transaction.Repository/DigitalBank.Api.Pub.Transaction.Repository.csproj DigitalBank.Api.Pub.Transaction.Repository/
COPY DigitalBank.Api.Pub.Transaction.Security/DigitalBank.Api.Pub.Transaction.Security.csproj DigitalBank.Api.Pub.Transaction.Security/

COPY . .

RUN dotnet restore

WORKDIR /src/DigitalBank.Api.Pub.Transaction
RUN dotnet build DigitalBank.Api.Pub.Transaction.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish DigitalBank.Api.Pub.Transaction.csproj -c Release -o /app


FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "DigitalBank.Api.Pub.Transaction.dll"]