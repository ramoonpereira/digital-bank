FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["DigitalBank.Api.Pub.Transaction/DigitalBank.Api.Pub.Transaction.csproj", "DigitalBank.Api.Pub.Transaction/"]
COPY ["DigitalBank.Api.Pub.Transaction.Business/DigitalBank.Api.Pub.Transaction.Business.csproj", "DigitalBank.Api.Pub.Transaction.Business/"]
COPY ["DigitalBank.Api.Pub.Transaction.Security/DigitalBank.Api.Pub.Transaction.Security.csproj", "DigitalBank.Api.Pub.Transaction.Security/"]
COPY ["DigitalBank.Api.Pub.Transaction.Repository/DigitalBank.Api.Pub.Transaction.Repository.csproj", "DigitalBank.Api.Pub.Transaction.Repository/"]
RUN dotnet restore "DigitalBank.Api.Pub.Transaction/DigitalBank.Api.Pub.Transaction.csproj"
COPY . .
WORKDIR "/src/DigitalBank.Api.Pub.Transaction"
RUN dotnet build "DigitalBank.Api.Pub.Transaction.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DigitalBank.Api.Pub.Transaction.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DigitalBank.Api.Pub.Transaction.dll"]