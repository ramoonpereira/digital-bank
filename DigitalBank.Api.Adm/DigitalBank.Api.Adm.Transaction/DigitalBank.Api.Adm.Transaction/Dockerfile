FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["DigitalBank.Api.Adm.Transaction/DigitalBank.Api.Adm.Transaction.csproj", "DigitalBank.Api.Adm.Transaction/"]
COPY ["DigitalBank.Api.Adm.Transaction.Security/DigitalBank.Api.Adm.Transaction.Security.csproj", "DigitalBank.Api.Adm.Transaction.Security/"]
COPY ["DigitalBank.Api.Adm.Transaction.Repository/DigitalBank.Api.Adm.Transaction.Repository.csproj", "DigitalBank.Api.Adm.Transaction.Repository/"]
COPY ["DigitalBank.Api.Adm.Transaction.Business/DigitalBank.Api.Adm.Transaction.Business.csproj", "DigitalBank.Api.Adm.Transaction.Business/"]
RUN dotnet restore "DigitalBank.Api.Adm.Transaction/DigitalBank.Api.Adm.Transaction.csproj"
COPY . .
WORKDIR "/src/DigitalBank.Api.Adm.Transaction"
RUN dotnet build "DigitalBank.Api.Adm.Transaction.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DigitalBank.Api.Adm.Transaction.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DigitalBank.Api.Adm.Transaction.dll"]