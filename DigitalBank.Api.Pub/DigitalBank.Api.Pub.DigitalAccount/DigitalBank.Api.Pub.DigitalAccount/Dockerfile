FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["DigitalBank.Api.Pub.DigitalAccount/DigitalBank.Api.Pub.DigitalAccount.csproj", "DigitalBank.Api.Pub.DigitalAccount/"]
COPY ["DigitalBank.Api.Pub.DigitalAccount.Security/DigitalBank.Api.Pub.DigitalAccount.Security.csproj", "DigitalBank.Api.Pub.DigitalAccount.Security/"]
COPY ["DigitalBank.Api.Pub.DigitalAccount.Repository/DigitalBank.Api.Pub.DigitalAccount.Repository.csproj", "DigitalBank.Api.Pub.DigitalAccount.Repository/"]
COPY ["DigitalBank.Api.Pub.DigitalAccount.Business/DigitalBank.Api.Pub.DigitalAccount.Business.csproj", "DigitalBank.Api.Pub.DigitalAccount.Business/"]
RUN dotnet restore "DigitalBank.Api.Pub.DigitalAccount/DigitalBank.Api.Pub.DigitalAccount.csproj"
COPY . .
WORKDIR "/src/DigitalBank.Api.Pub.DigitalAccount"
RUN dotnet build "DigitalBank.Api.Pub.DigitalAccount.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DigitalBank.Api.Pub.DigitalAccount.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DigitalBank.Api.Pub.DigitalAccount.dll"]