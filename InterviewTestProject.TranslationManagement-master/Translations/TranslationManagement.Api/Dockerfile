#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["/Translations/TranslationManagement.Api/TranslationManagement.Api.csproj", "Translations/TranslationManagement.Api/"]
COPY ["/Translations/TranslationManagement.Domain/TranslationManagement.Domain.csproj", "Translations/TranslationManagement.Domain/"]
COPY ["/Translations/TranslationManagement.Infrastructure/TranslationManagement.Infrastructure.csproj", "Translations/TranslationManagement.Infrastructure/"]
COPY ["/External.ThirdParty.Services/External.ThirdParty.Services.csproj", "External.ThirdParty.Services/"]
RUN dotnet restore "Translations/TranslationManagement.Api/TranslationManagement.Api.csproj"
COPY . .
WORKDIR "/src/Translations/TranslationManagement.Api"
RUN dotnet build "TranslationManagement.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TranslationManagement.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TranslationManagement.Api.dll"]
