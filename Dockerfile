FROM registry.cn-hangzhou.aliyuncs.com/shinetechchina/dotnet_core_sdk:3.1 AS build-env
WORKDIR /app

COPY . /app
# Copy csproj and restore as distinct layers
RUN sed -i "s/127.0.0.1/172.18.0.1/g" web-backend/appsettings.json
# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out

# Build runtime image
FROM registry.cn-hangzhou.aliyuncs.com/microsoft-mirror/dotnetcore_runtime:3.1
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "web-backend.dll"]