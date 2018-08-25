FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["ContainerWebAppDemo/ContainerWebAppDemo.csproj", "ContainerWebAppDemo/"]
RUN dotnet restore "ContainerWebAppDemo/ContainerWebAppDemo.csproj"
COPY . .
WORKDIR "/src/ContainerWebAppDemo"
RUN dotnet build "ContainerWebAppDemo.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "ContainerWebAppDemo.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "ContainerWebAppDemo.dll"]