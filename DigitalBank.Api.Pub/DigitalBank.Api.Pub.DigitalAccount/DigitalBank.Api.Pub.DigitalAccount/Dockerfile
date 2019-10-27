FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build-env
WORKDIR /app
EXPOSE 80

WORKDIR /src

COPY DigitalBank.Api.Pub.DigitalAccount/DigitalBank.Api.Pub.DigitalAccount.csproj DigitalBank.Api.Pub.DigitalAccount/
COPY DigitalBank.Api.Pub.DigitalAccount.Business/DigitalBank.Api.Pub.DigitalAccount.Business.csproj DigitalBank.Api.Pub.DigitalAccount.Business/
COPY DigitalBank.Api.Pub.DigitalAccount.Repository/DigitalBank.Api.Pub.DigitalAccount.Repository.csproj DigitalBank.Api.Pub.DigitalAccount.Repository/
COPY DigitalBank.Api.Pub.DigitalAccount.Security/DigitalBank.Api.Pub.DigitalAccount.Security.csproj DigitalBank.Api.Pub.DigitalAccount.Security/

COPY . .

RUN dotnet restore

WORKDIR /src/DigitalBank.Api.Pub.DigitalAccount


FROM build AS publish
RUN dotnet publish DigitalBank.Api.Pub.DigitalAccount.csproj -c Release -o /app


FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "DigitalBank.Api.Pub.DigitalAccount.dll"]