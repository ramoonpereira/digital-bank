FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["DigitalBank.Api.Adm.DigitalAccount/DigitalBank.Api.Adm.DigitalAccount.csproj", "DigitalBank.Api.Adm.DigitalAccount/"]
COPY ["DigitalBank.Api.Adm.DigitalAccount.Security/DigitalBank.Api.Adm.DigitalAccount.Security.csproj", "DigitalBank.Api.Adm.DigitalAccount.Security/"]
COPY ["DigitalBank.Api.Adm.DigitalAccount.Repository/DigitalBank.Api.Adm.DigitalAccount.Repository.csproj", "DigitalBank.Api.Adm.DigitalAccount.Repository/"]
COPY ["DigitalBank.Api.Adm.DigitalAccount.Business/DigitalBank.Api.Adm.DigitalAccount.Business.csproj", "DigitalBank.Api.Adm.DigitalAccount.Business/"]
RUN dotnet restore "DigitalBank.Api.Adm.DigitalAccount/DigitalBank.Api.Adm.DigitalAccount.csproj"
COPY . .
WORKDIR "/src/DigitalBank.Api.Adm.DigitalAccount"
RUN dotnet build "DigitalBank.Api.Adm.DigitalAccount.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DigitalBank.Api.Adm.DigitalAccount.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DigitalBank.Api.Adm.DigitalAccount.dll"]