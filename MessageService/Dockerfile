FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY MessageService/MessageService.csproj MessageService/
COPY BusinessEntities/BusinessEntities.csproj BusinessEntities/
RUN dotnet restore MessageService/MessageService.csproj
COPY . .
WORKDIR /src/MessageService
RUN dotnet build MessageService.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish MessageService.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "MessageService.dll"]
