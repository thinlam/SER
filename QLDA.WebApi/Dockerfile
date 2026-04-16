FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base

RUN apt-get update &&  \
    apt-get install -y wget &&  \
    rm -rf /var/lib/apt/lists/*

# Thêm đoạn này để cài libgdiplus
RUN apt-get update && \
    apt-get install -y --no-install-recommends libgdiplus && \
    ln -s /usr/lib/libgdiplus.so /usr/lib/gdiplus.dll && \
    rm -rf /var/lib/apt/lists/* \
    
USER $APP_UID    
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
# Change BUILD_CONFIGURATION to 'Release' for Production/Staging environments
# Change BUILD_CONFIGURATION to 'Debug' for Development environment
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["QLDA.WebApi/QLDA.WebApi.csproj", "QLDA.WebApi/"]
COPY ["QLDA.Application/QLDA.Application.csproj", "QLDA.Application/"]
COPY ["../../../SharedKernel/src/SharedKernel.Application/SharedKernel.Application.csproj", "SharedKernel/src/SharedKernel.Application/"]
COPY ["../../../SharedKernel/src/SharedKernel.Domain/SharedKernel.Domain.csproj", "SharedKernel/src/SharedKernel.Domain/"]
COPY ["../../../SharedKernel/src/SharedKernel.Infrastructure/SharedKernel.Infrastructure.csproj", "SharedKernel/src/SharedKernel.Infrastructure/"]
COPY ["../../../SharedKernel/src/SharedKernel.Persistence/SharedKernel.Persistence.csproj", "SharedKernel/src/SharedKernel.Persistence/"]
COPY ["QLDA.Domain/QLDA.Domain.csproj", "QLDA.Domain/"]
COPY ["QLDA.Persistence/QLDA.Persistence.csproj", "QLDA.Persistence/"]
COPY ["QLDA.Infrastructure/QLDA.Infrastructure.csproj", "QLDA.Infrastructure/"]
RUN dotnet restore "QLDA.WebApi/QLDA.WebApi.csproj"
COPY . .
WORKDIR "/src/QLDA.WebApi"
RUN dotnet build "./QLDA.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./QLDA.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
# Change ASPNETCORE_ENVIRONMENT to 'Production' or 'Staging' as needed
# Change ASPNETCORE_ENVIRONMENT to 'Development' as needed
ENV ASPNETCORE_ENVIRONMENT=Staging
# Override SwaggerPathBase for Docker builds
ENV SwaggerPathBase=/qlda
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "QLDA.WebApi.dll"]
