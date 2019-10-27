FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["DigitalBank.Worker.Transaction/DigitalBank.Worker.Transaction.csproj", "DigitalBank.Worker.Transaction/"]
COPY ["DigitalBank.Worker.Transaction.Security/DigitalBank.Worker.Transaction.Security.csproj", "DigitalBank.Worker.Transaction.Security/"]
COPY ["DigitalBank.Worker.Transaction.Repository/DigitalBank.Worker.Transaction.Repository.csproj", "DigitalBank.Worker.Transaction.Repository/"]
COPY ["DigitalBank.Worker.Transaction.Business/DigitalBank.Worker.Transaction.Business.csproj", "DigitalBank.Worker.Transaction.Business/"]
RUN dotnet restore "DigitalBank.Worker.Transaction/DigitalBank.Worker.Transaction.csproj"
COPY . .
WORKDIR "/src/DigitalBank.Worker.Transaction"
RUN dotnet build "DigitalBank.Worker.Transaction.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DigitalBank.Worker.Transaction.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DigitalBank.Worker.Transaction.dll"]