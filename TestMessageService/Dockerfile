FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["TestMessageService/TestMessageService.csproj", "TestMessageService/"]
RUN dotnet restore "TestMessageService/TestMessageService.csproj"
COPY . .
WORKDIR "/src/TestMessageService"
RUN dotnet build "TestMessageService.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "TestMessageService.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "TestMessageService.dll"]