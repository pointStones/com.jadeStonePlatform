FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["com.jadeStonePlatform.web/com.jadeStonePlatform.web.csproj", "com.jadeStonePlatform.web/"]
RUN dotnet restore "com.jadeStonePlatform.web/com.jadeStonePlatform.web.csproj"
COPY . .
WORKDIR "/src/com.jadeStonePlatform.web"
RUN dotnet build "com.jadeStonePlatform.web.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "com.jadeStonePlatform.web.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "com.jadeStonePlatform.web.dll"]