FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ImageService/ImageService.csproj ImageService/
RUN dotnet restore ImageService/ImageService.csproj
COPY . .
WORKDIR /src/ImageService
RUN dotnet build ImageService.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish ImageService.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "ImageService.dll"]
