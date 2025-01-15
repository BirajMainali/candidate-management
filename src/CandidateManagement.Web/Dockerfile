FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/CandidateManagement.Web/CandidateManagement.Web.csproj", "src/CandidateManagement.Web/"]
COPY ["src/CandidateManagement.Infrastructure/CandidateManagement.Infrastructure.csproj", "src/CandidateManagement.Infrastructure/"]
COPY ["src/CandidateManagement.Domain/CandidateManagement.Domain.csproj", "src/CandidateManagement.Domain/"]
COPY ["src/CandidateManagement.Contracts/CandidateManagement.Contracts.csproj", "src/CandidateManagement.Contracts/"]
COPY ["src/CandidateManagement.Application/CandidateManagement.Application.csproj", "src/CandidateManagement.Application/"]
COPY ["src/CandidateManagement.Presentation/CandidateManagement.Presentation.csproj", "src/CandidateManagement.Presentation/"]
RUN dotnet restore "src/CandidateManagement.Web/CandidateManagement.Web.csproj"
COPY . .
WORKDIR "/src/src/CandidateManagement.Web"
RUN dotnet build "CandidateManagement.Web.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "CandidateManagement.Web.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CandidateManagement.Web.dll"]
